    [System.Serializable]
    public class Item {
    
        [XmlAttribute("name")]
        public string name = "";
        [XmlAttribute("type")]  
        public string type;
        [XmlAttribute("value")]
        public int value = 0;
        [XmlAttribute("weight")]
        public float weight = 0.0f;
    
        [XmlElement("mods")]
        public Mods mods = new Mods();
    }
    [System.Serializable]
    public class Mods
    {
        [XmlAttribute("healthMod")]
        public int healthMod = 0;
        [XmlAttribute("staminaMod")]
        public int staminaMod = 0;
        [XmlAttribute("manaMod")]
        public int manaMod = 0;}
    }
