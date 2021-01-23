    private const string Query = "SELECT * FROM 'reportsetting` order by SendingTime;"
    protected override void OnStart(string[] args)
    {
        _timer = new Timer(40 * 1000); // every 40 seconds
        _timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        _timer.Start(); // <- important
    }
    private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        MySqlConnection con = new MySqlConnection(conn);
        MySqlCommand comm = new MySqlCommand(Query, con);
        con.Open();
        MySqlDataReader dr = comm.ExecuteReader();
        while (dr.Read())
        {
            time = dr["SendingTime"].ToString();
            if ((str = DateTime.Now.ToString("HH:mm")).Equals(time))
            {
                //Execute Function and send reports based on the data from the database.
                Thread thread = new Thread(sendReports);
                thread.Start();
            }
        }
    }
