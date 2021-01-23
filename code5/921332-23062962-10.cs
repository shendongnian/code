    class User {
        public int idUser {get;set;}
        public int ComputerID {get;set;}
        public virtual Computer Computer {get;set;}
    }
    class Computer {
        public int idComputer {get;set;}
    
        public virtual ICollection<User> Users {get;set;}
    }
