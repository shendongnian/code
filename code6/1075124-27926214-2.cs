    public void Do(object args)
    {
        // pre-procedure of A
        foreach (B b in _bs)
        {
            b.Do(args);
        }
        // post-procedure of A
    }
