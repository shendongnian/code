    private static Timer timer;
    private const int TimerInterval = 30000;
    protected override void OnStart(string[] args)
    {
        var callback = new TimerCallback(checkDatabase);
        this.timer = new Timer(callback, null, 0, TimerInterval);
    }
    private void checkDatabase()
    {
        string query = "SELECT * FROM 'reportsetting` order by SendingTime;";
        using (var con = new MySqlConnection(conn))
        using (var cmd = new MySqlCommand(query, con))
        {
            con.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    // do some work
                }
            }
        }
    }
