    public class Stat
    {
     public int Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public virtual List<Quantity> Quantities { get; set; }
     [ScriptIgnore]
     public virtual List<Hit> Hits { get; set; }
    }
