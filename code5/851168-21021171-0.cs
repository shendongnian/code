    public string Name {get; set;}
    public DateTime Time {get; set;}
    public Caller(IClass evObjParm)
    {
        Name = evObjParm.Name;
        Time = evObjParm.Time;
    }
