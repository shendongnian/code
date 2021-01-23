    public float shooting delay;    
    bool _canShoot;
    public static bool canShoot
    {
        get { return _canShoot; }
        set { _canShoot = value; StartCoroutine(EnableShooting()); }
    }
    
    IEnumerator EnableShooting()
    {
        yield return new WaitForSeconds(delay);
        _canShoot = true;
    }
    
