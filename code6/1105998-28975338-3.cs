    public class Dojo
    {
        public int DojoId { get; set;}
        public DojoProperty PropOne { get; protected set;}
        public DojoProperty PropTwo{ get; protected set; }
        public virtual ICollection<ISamurai> Warriors { get; set; }
        
        private Dojo(){}
        public static Dojo Create(IDojoConfig dojoConfig)
        {
            return new Dojo() {PropOne = dojoConfig.PropOne, PropTwo = dojoConfig.PropTwo};
        }
    }
