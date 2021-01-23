    [Serializable]
    [XmlRoot("Booking")]
    public class Booking : List<Included>
    {
    }
    
    [Serializable]
    public class Included
    {
        public Meals Meals { get; set; }
        public Drinks Drinks { get; set; }
    }
    public class Meals
    {
        [XmlAttribute("Breakfast")]
        public string Breakfast { get; set; }
        [XmlAttribute("Lunch")]
        public string Lunch { get; set; }
        [XmlAttribute("Dinner")]
        public string Dinner { get; set; }
    }
    public class Drinks
    {
        [XmlAttribute("Soft")]
        public string Softs { get; set; }
        [XmlAttribute("Beer")]
        public string Beer { get; set; }
        [XmlAttribute("Wine")]
        public string Wine { get; set; }
    }
