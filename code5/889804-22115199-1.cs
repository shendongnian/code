        private SQLite GetConnection()
        {
            return new SQLiteConnection("Data Source=|DataDirectory|\\db.sqlite3;");
        }
        private void LoadData()
        {
            using(SQLiteConnection cn = GetConnection())
            {
                cn.Open();
                string CommandText = "select * from scotty_fahrt";
                DB = new SQLiteDataAdapter(CommandText, sql_con);
                DS.Reset();
                DB.Fill(DS);
                DT = DS.Tables[0];
                GVOutput.DataSource = DT;
            }
        }
