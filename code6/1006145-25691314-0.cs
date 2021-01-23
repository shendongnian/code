    public onStart()
    {
       timer.Interval = 1000;
       timer.Enabled = true;
    }   
    
    public onTimerTick(...)
    {
        timer.Enabled = false;
        using (var conn = new MySqlConnection("Server=xx.xx.xx.xx;Port=3306;Database=kbindb;Uid=collector; Pwd=xxx;"))
        {
            conn.Open();
            using (var com = new MySqlCommand("SELECT * FROM blabla;", conn))
            {
                var reader = com.ExecuteReader();
                while (dr.Read())
                {
                    //blabla
                }
            }
        }
        timer.Enabled = true;
    }
