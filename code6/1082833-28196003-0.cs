    public class Soccer
    {
        public static Mapping.Mapping Mappings { get; private set; }
    
        internal Soccer()  //  <-- instead of 'public'
        {
            Mappings = new Mapping.Mapping();
        }
    }
    public class Mapping
    {
        internal Mapping()
        {
        }
    }
