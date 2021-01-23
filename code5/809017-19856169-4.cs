    using (var m_dbConnection = new SQLite.SQLiteConnection(dbPath))
    {
        m_dbConnection.Insert(new highscore()
        {
            name = "Me",
            score = 9001
        });
        m_dbConnection.Insert(new highscore()
        {
            name = "Me",
            score = 3000
        });
        m_dbConnection.Insert(new highscore()
        {
            name = "Myself",
            score = 6000
        });
        m_dbConnection.Insert(new highscore()
        {
            name = "And I",
            score = 9001
        });
    }
