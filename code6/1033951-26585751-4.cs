    private void button3_Click(object sender, EventArgs e)
    {
            aTimer = new System.Timers.Timer(2000);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.Enabled = true;
    }
    
    private static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        GPS a = new GPS("A"); 
        Random rnd = new Random();
        Random time_skip = new Random();
        Int32 skip_or_not = time_skip.Next(-61, 600);//if <0 then GPS off
    
        //We check if skip_or_not < 0
        if(skip_or_not<0)//GPS off or off radar
        {
            Int32 tChangePos = rnd.Next(-50, 50);
            a.setLoc(tChangePos);
            DateTime w = DateTime.Now;
            TimeSpan timew = new TimeSpan(0, 0, 20, 0,0);//20 mins off radar
            DateTime combined = w.Add(timew);
            a.setDate(combined);
        }
        else
        {
            Int32 ChangePos = rnd.Next(-6, 6);
            a.setLoc(ChangePos);
            a.setDate(DateTime.Now);
        }
    
        string stmt = "INSERT INTO m(TIME,LOCATION,NAME) VALUES(@time, @location,@name)";
        SqlCommand cmd = new SqlCommand(stmt, cs);
        cmd.Parameters.Add("@time", SqlDbType.VarChar, 100);
        cmd.Parameters.Add("@location", SqlDbType.VarChar, 100);
        cmd.Parameters.Add("@name", SqlDbType.VarChar, 100);
        cmd.Parameters["@time"].Value = a.getDate().ToString("t");
        cmd.Parameters["@location"].Value = a.getLoc().ToString();
        cmd.Parameters["@name"].Value = a.ObjName.ToString();
    
        cs.Open();
        cmd.ExecuteNonQuery();
        cs.Close();
    }
