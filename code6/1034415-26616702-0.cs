    public class Foo 
    {
        ...
        [References(typeof(Bar))]
        public long BarAId { get; set; }
    
        [Reference]
        public Bar BarA { get; set; }
    
        [References(typeof(Bar))]
        public long BarBId { get; set; }
    
        [Reference]
        public Bar BarB { get; set; }
    }
