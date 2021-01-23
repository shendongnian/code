    public class OrderContract { 
        public string email {get;set;}
        public string name {get;set;}
        public string mobile{get;set;}
    }
    public class InfoContract {
        public List<OrderContract> Info {get;set;}
    }
