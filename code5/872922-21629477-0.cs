    public Material a;
    public Material b;
	void Update () 
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (renderer.sharedMaterial == a)
            {
                gameObject.renderer.material = b;
            }
            else
            {
                gameObject.renderer.material = a;
            }
        }
	}
