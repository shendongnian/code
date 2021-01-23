    class User {
        public int ID {get;set;} // auto detected by EF as PK, no need to specify [Key] data annotation above it
    }
    class Computer {
        public int ID {get;set;} // auto-detected by EF as PK
    }
