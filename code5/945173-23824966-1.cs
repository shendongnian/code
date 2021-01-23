    class MyObject {
        public string Name {get;set;}
        public DateTime Dob {get;set;}
        public override string ToString() {
            return string.Format("{0} - {1}", Name, Dob);
        }
    }
