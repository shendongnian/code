    public void OtherStuffFromThread2()
    {
        Thread.Sleep(Timespan.FromMinutes(1));
        // Implicit MemoryBarrier here :-)
        //how do I ensure that I have the latest bar ref here
        //considering mem cahces etc
        bar.Something();
    }
