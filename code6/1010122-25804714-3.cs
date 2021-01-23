    //Will lock only when the condition is true
    using (var myLock = new LockHelper(some condition))
    {
        if (wrappersProduced < myQ.BoundedCapacity)
        {
            try
            {
                WordApplicationWrapper w = new WordApplicationWrapper();
                myQ.Add(w);
                wrappersProduced++;
                //exit
                if (wrappersProduced == 100)
                    myLock.Exit();
                Logger.DebugMemory("Wrappers Produced - " + wrappersProduced.ToString());
            }
            catch (Exception e)
            {
                Logger.DebugMemory("Couldn't add Wrapper - " + e.Message);
            }
        }
    }
