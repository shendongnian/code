    public void Function1()
    {
        //Do camera stuff
        Image image = MagicalCameraStuff();
        //Create a thread that the processing will occur on
        Thread process = new Thread(() => Function2(image));
        //Start the thread
        process.Start();
    }
    public void Function2(Image i)
    {
        //Do some processing without blocking the main thread
    }
