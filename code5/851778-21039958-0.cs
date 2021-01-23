    public int ammoInFullClip = 30;
    public int ammoCount = 30;
    public string ammoText;
    void magazine()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            ammoCount-= 1;
        }
    
        if (Input.GetKey(KeyCode.R))
        {
            ammoCount = ammoInFullClip;
        }
        ammoText = string.Concat("AMMO ", ammoCount, "/30");
    }
