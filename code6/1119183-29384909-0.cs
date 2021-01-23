    class Settings {
        public string Property1 { get; set; }
        public int Property2 { get; set; }
    
        public bool IsValid() {
            if(string.IsNullOrEmpty(Property1)) return false;
            if(Property2 == 0) return false;
        }
    }
