    public class Country
    {
            public string Iso { get; set; }
            public string Name { get; set; }
            public string ContinentIso { get; set; }
            public virtual Continent Continent { get; set; }
    }
