    public IEntity Selected
    {
        get { return Entities.Current as IEntity; }
        set { Entities.Position = Entities.IndexOf(value); }
    }
