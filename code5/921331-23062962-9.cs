    class User {
        public int idUser {get;set;}
        
        public virtual ICollection<Computer> Computers {get;set;}
    }
    class Computer {
        public int idComputer {get;set;}
        
        public int UserID {get;set;} // automatically detected as a ForeignKey since the format it [classname]ID
        public virtual User User {get;set;}
    }
