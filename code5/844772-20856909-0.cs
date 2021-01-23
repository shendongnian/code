    public void Process(Action callback)
    {
        bool done = false;
        do {
            //do stuff
            callback();
        }while (!done);
    }
