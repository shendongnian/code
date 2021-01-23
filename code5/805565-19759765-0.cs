    void OnCollisionEnter(Collision obj)
    {
        PlatformMove platform = obj.gameObject.GetComponent<PlatformMove>();
        if(platform != null){
            if(platform.platformColor.ToString() == joeColor.ToString()) {
                //... do stuff
            }
        } else {
            //... collision object did not have a PlatformMove component.
        }
    }
