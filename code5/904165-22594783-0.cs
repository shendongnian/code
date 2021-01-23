    public class Tree
    {
       
        [XmlIgnore]
        public Point Location { get; set;}
        
        [XmlAttribute]
        public double X { 
            get { return Location.X;} 
            set { Location = new Point(value, Location.Y); }
        }
        
        [XmlAttribute]
        public double Y { 
            get { return Location.Y;} 
            set { Location = new Point(Location.X, value); }
        }
    }
    
    public class AppleTree : Tree
    {
        [XmlAttribute]
        public int FruitCount { get; set; }
    }
