    bool _IsStop = false;
    protected override void OnStart(string[] args)
    {
            base.OnStart(args);
            while (!this._IsStop)
            {
                this.Process();
                //40 seconds time out
                Thread.Sleep(1000*40); //1000 is 1 second
            }
            //If we reach here
            //Do some clean up here
        }
        protected override void OnStop()
        {
            //Service is stop by the user on service or by OS
            this._IsStop = true;
        }
        private void Process()
        {
            string Query = "";
            // -->>>  if you use something like this on your query and little bit setup on your db
            // this will give you a more efficient memory usage
            Query = "SELECT * FROM reportsetting where [your tag if already sent] = false and SendingTime <= [current date and time]  order by SendingTime;";
            MySqlConnection con = new MySqlConnection(conn);
            MySqlCommand comm = new MySqlCommand(Query, con);
            con.Open();
            MySqlDataReader dr = comm.ExecuteReader();
            while (dr.Read())
            {
                    //Execute Function and send reports based on the data from the database.
                    Thread thread = new Thread(sendReports);
                    thread.Start();
                    //sleep for half a second before proceeding to the next record if any
                    Thread.Sleep(500); 
            }
        }
