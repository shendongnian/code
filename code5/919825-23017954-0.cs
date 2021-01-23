    [Serializable]
    public class Lot_information {    
        public Component[] components { get; set; }
        public Control[] families { get; set; }
        public string lot_exp_date { get; set;}
        public int lot_number { get; set;}
    }
    [Serializable]
    public class Component {    
        public int target { get; set; }    
        public int min { get; set; }    
        public int max { get; set; }    
        public int number { get; set; }
        public string control { get; set; }
        public string @ref { get; set; }
        public string family { get; set; }
        public int component { get; set; }
        public string id { get; set; }
    }
    [Serializable]
    public class Control {
        public string family { get; set; }
        public string ctrl { get; set; }
    }
