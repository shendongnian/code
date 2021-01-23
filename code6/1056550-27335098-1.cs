    override void OnCreate()
    {
        // some stuff
        if (!ClientObjects.IsLoaded) 
        {
            LoadSystemData().Wait();
        }
        // some other stuff
    }
