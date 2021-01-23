    bool SomethingOne()
    {
        var successful = true;
        //Do something...
        //If something fail
            successful = false;
        return successful;
    }
    bool SomethingTwo()
    {
        var successful = true;
        //Do something...
        //If something fail
            successful = false;
        return successful;
    }
    void Function1()
    {
        var isOneSuccessful = SomethingOne();
        if (!isOneSuccessful)
        {
            // SomethingOne failed - do something
            return;
        }
        var isTwoSuccessful = SomethingTwo();
        if (!isTwoSuccessful)
        {
            // SomethingTwo failed - do something
            return;
        }
        //If everything its ok, just continue without throwing anything
    }
