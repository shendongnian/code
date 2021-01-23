    class User {
        public int ID {get;set;}
        public virtual Computer Computer {get;set;}
    }
    class Computer {
        public int ID {get;set;}
    
        [Required]
        public int UserID {get;set;}
        public virtual User User {get;set;}
    }
