    public class Menu 
    {
        [XmlElement("apple",typeof(Apple))]
        public Fruit fruit {get;set;}
    
        public bool ShouldSerializefruit()
        {
            return !(fruit is Pineapple);
        }
    
    }
