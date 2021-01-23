    //in MyType definition
    public MyType(MyType objectToCopy)
    {
        Movie = new List<MySubType>(m.Movie);
        Ranks = m.Ranks;
        Location = m.Location;
        Released = m.Released;
    }
