    public class jsonWrapper
    {
        public Seven seven { get; set; }
    }
    
    public class Seven
    {
        public All all { get; set; }
    }
    
    public class All
    {
        public Cars cars { get; set; }
    }
    
    public class Cars
    {
        public Portrait Portrait { get; set; }
    }
    
    public class Portrait
    {
        public Landscape Landscape { get; set; }
    }
    
    public class Landscape
    {
        public Background Background { get; set; }
    }
    
    public class Background
    {
         public Element[] Elements { get; set; } // the only array I see in your json
    }
    
    public class Element
    {
        //properties that you have collapsed
    }
