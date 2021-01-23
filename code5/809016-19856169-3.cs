    public class highscore
    {
        [MaxLength(20)]
        public string name { get; set; }
        public int score { get; set; }
    }
    using (var m_dbConnection = new SQLite.SQLiteConnection(dbPath))
    {
        m_dbConnection.CreateTable<highscore>();
    }
    
