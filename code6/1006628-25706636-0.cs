    public class Props
    {
       public string PropA { get; private set; }
       public string PropB { get; private set; }
       public string PropC { get; private set; }
    }
    public Props() { }
    public SetProps(string propA, string propB, string propC)
    {
        this.PropA = propA;
        this.PropB = propB;
        this.PropC = propC;
    }
