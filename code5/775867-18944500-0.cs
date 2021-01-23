    public override void LockIt()
    {
        bool locked = false;
        try
        {
            spinLock.Enter(ref locked);
        }
        finally
        {
            if(locked)
                spinLock.Exit();
        }
    }
