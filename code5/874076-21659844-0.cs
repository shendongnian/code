    [Serializable]
    public class AdressData
    {
        [XmlArrayItem("Adress")]
        public Adress[] Adresses
    }
    
    [Serializable]
    public class Adress
    {
        public string Street {get; set;}
        public int Number {get; set;}
        public int Zip{get; set;}
        public string City{get; set;}
        public string State{get; set;}
    }
