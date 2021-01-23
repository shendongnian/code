    class SomeClass
    {
        public string BankName {get;set;}
        public int SchoolId {get;set;}
    }
    SchoolSoulLibrary.SchoolSoulDataEntities ss = new SchoolSoulLibrary.SchoolSoulDataEntities();
    string query1;
        var li = ss.Database.SqlQuery<SomeClass>(query1).ToList();
