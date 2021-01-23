    public class Round 
    {
       public Round Parent { get; set; }
       public int Depth { get; set; }
       public string Value { get; set; }
       public IList<Round> Nodes { get; set; }
    }
