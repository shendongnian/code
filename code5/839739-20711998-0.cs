    public ReadOnlyCollection<Dog> Snapshot
    {
        get
        {
            return new ReadOnlyCollection<Dog>(_dogs);
        }
    }
