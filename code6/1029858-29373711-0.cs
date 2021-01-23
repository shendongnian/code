    userDatabase.CreateTable<MyObject>();
    //class file
    [SQLite.Table("MyObject")]
    public class MyObject
    {
        public int IdOne { get; set; }
        public int IdTwo { get; set; }
        [SQLite.PrimaryKey]
        public string auxCompositeKey {get; set;}
    }
