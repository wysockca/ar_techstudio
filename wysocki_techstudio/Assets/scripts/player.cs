using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public Animator anim;
    public Rigidbody rbody;
    public string runBtn = "Running";
    public string attackBtn = "Attack";
    

    private float inputH;
    private float inputV;
    //private bool run;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputH = SimpleInput.GetAxis("Horizontal");
        inputV = SimpleInput.GetAxis("Vertical");

        anim.SetFloat("inputH", inputH);
        anim.SetFloat("inputV", inputV);

        float moveX = inputH * 20f * Time.deltaTime;
        float moveZ = inputV * 50f * Time.deltaTime;

        rbody.velocity = new Vector3(moveX, 0f, moveZ);

        if (SimpleInput.GetButtonDown("Attacking"))
            anim.SetBool("attack", true);

        if (SimpleInput.GetButtonUp("Attacking"))
            anim.SetBool("attack", false);

        if (SimpleInput.GetButtonDown("Running"))
            anim.SetBool("run", true);

        if (SimpleInput.GetButtonUp("Running"))
            anim.SetBool("run", false);
    }
}
