    public class Info
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string imageUrl { get; set; }
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [Ignore]
        public DetailInfo objDetailInfo{ get; set; }
    }
    public class DetailInfo
    {
        public string phoneno { get; set; }
        public string address { get; set; }
    }
    public void createtable()
    {
       SQLite.SQLiteConnection db= new SQLite.SQLiteConnection(dbPath);
       db.CreateTable<Info>();
       db.CreateTable<DetailInfo>();
    }
