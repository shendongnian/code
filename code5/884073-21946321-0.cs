    public class Parent
    {
        public int id {get; set;}
        public string name {get;set;}
        public int childId {get;set;
        public virtual child child {get;set;}
    }
    public class child
    {
       public int id {get; set;}
       public string name {get;set;}
    }
