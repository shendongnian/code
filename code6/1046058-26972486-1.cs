    public IEntity Selected
    {
        get { return Entities.Current as IEntity; }
        set { Entities.Position = Entities.IndexOf(value); }
    }
    public List<IEntity> DataSource
    {
        set
        {
            Entities.DataSource = value;
            NotifyProperty("DataSource");
        }
    }
