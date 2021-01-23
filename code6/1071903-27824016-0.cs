    public string getLevelName()
    {
        using (var c = new myContext())
        {
           return getLevelNameFrom(c);
        }
    
    }
    public string getLevelNameFrom(MyContext c)
    {
            Contract.Ensures(Contract.Result<string>() == c.Level.FirstOrDefault(i => i.levelId == this.levelId).name);
            return c.Level.FirstOrDefault(i => i.levelId == this.levelId).name;
    }
