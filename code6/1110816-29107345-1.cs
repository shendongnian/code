    public void OtherStuffFromThread2()
    {
        while (true)
        {
            //how do I ensure that I have the latest bar ref here
            //considering mem cahces etc
            bar.Something();
        }
    }
