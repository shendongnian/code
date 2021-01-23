    IList<Swimmer> AllSwimmers;
    public Swimmers()
    {
        AllSwimmers = new List<Swimmer>();
    }
    ...
    string name = Console.ReadLine();
    Swimmer swimmer = AllSwimmers.Single(x => x.Name == name);
    return swimmer;
    // or, if you really want the index, remove the above line and continue with:
    int pos = AllSwimmers.IndexOf(swimmer);
    return pos;
