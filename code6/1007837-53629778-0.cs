    void Awake () {
        if(control == null)
        {
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
