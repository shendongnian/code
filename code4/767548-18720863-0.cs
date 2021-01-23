    public class Department {
        public string Address1 {get;set;}
        public string Address2 {get;set;}
        public string Address {
            get { return Address1 + Environment.NewLine + Address2; }
        }
    }
