    public string FullName
    {
        get { return string.Format("{0} {1}", this.Name1, this.Name2); }
        set 
        {
            //Note that this needs validation etc. applying to be robust
            var names = value.Split(" ");
            Name1 = names[0];
            Name2 = names[0];
        }
    }
