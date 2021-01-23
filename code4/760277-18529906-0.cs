    public class customer
    {
        public string name { get; set; }
        public string address { get; set; }
    }
    public class mycustomer : customer
    { 
        // name and address are inherited
        public string email { get; set; }
    }
