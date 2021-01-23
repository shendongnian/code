    public int ammoInFullClip = 30;
    private int currentAmmoCount = 30;
    private string ammoText;
    void magazine()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            currentAmmoCount-= 1;
        }
    
        if (Input.GetKey(KeyCode.R))
        {
            currentAmmoCount= ammoInFullClip;
        }
        ammoText = string.Format("AMMO {0}/{1}", currentAmmoCount, ammoInFullClip);
    }
