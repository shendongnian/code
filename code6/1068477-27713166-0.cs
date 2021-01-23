    public class Lookups : ILookups
    {
        public HashSet<string> FirstNames { get; set; }
    
        IEnumerable<string> ILookups.FirstNames { get { return this.FirstNames; } }
    }
