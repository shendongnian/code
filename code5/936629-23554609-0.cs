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
        public Producing_Unit Producing_Unit { get; set; }
        
        [XmlIgnoreAttribute]
        public Unit Unit
        {
            get { return Producing_Unit.Unit; }
            set { Producing_Unit.Unit = value; }
        }
    }
