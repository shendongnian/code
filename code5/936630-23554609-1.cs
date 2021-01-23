    public class Unit
    {
        public string Name { get; set; }
        public string ID { get; set; }
    }
    
    public class Producing_Unit
    {
        public Unit Unit { get; set; }
    }
    
    public class Produced_by
    {
        private Producing_Unit producing_unit;
        public Producing_Unit Producing_Unit //This can't be auto-implemented since can write to properties of properties.
        { 
            get { return producing_Unit; } 
            set { producing_Unit = value; }
        }
        
        [XmlIgnoreAttribute]
        public Unit Unit
        {
            get { return producing_Unit.Unit; }
            set { producing_Unit.Unit = value; }
        }
    }
