         /// <summary>
            /// Your Timer.
            /// </summary>
            private System.Timers.Timer timer;
    
      protected override void OnStart(string[] args)
        {
            this.timer = new System.Timers.Timer("(Take time from database or use static time)");
    
            // Hook up the Elapsed event for the timer.
            this.timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
    
            this.timer.Enabled = true;
    
    
            string conn = "Server=localhost;Port=3306;Database=;UID=root;Pwd=;pooling=false";
            string Query = "SELECT * FROM `reportsetting` order by SendingTime desc limit 1;";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand comm = new MySqlCommand(Query, con);
            con.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
    
            }
        }
    
        protected override void OnStop()
        {
        }
    
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
              // Your code when the timer elapses
        }
