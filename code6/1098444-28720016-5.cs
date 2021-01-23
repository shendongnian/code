    public bool Locked
    { get { return this.key != null; } }
    
    public void Lock(object obj)
    {
        if (this.key == null)
        {
            this.key = obj;
        }
    }
    public void Unlock(object obj)
    {
        if (this.key == obj)
        {
            this.key = null;
        }
    }
