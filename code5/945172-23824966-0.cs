    class MyObject {
        public string Name {get;set;}
        public DateTime Dob {get;set;}
        public string ToString() {
            return string.Format("{0} - {1}", Name, Dob);
        }
    }
