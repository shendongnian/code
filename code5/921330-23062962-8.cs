    class User {
        public int idUser {get;set;}
        public virtual Computer Computer {get;set;}
    }
    class Computer {
        public int idComputer {get;set;}
    
        public int UserID {get;set;}
        public virtual User User {get;set;}
    }
