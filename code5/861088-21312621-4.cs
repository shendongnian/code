    public class User
    {
        public int UserID {get; set;}
        public string StateID {get; set;}
        public virtual State State{get; set;}
    }
    
    public class State
    {
        public string StateID {get; set;}
        public string StateName { get; set; }
        public virtual List<User> Users { get; set; }
    }
