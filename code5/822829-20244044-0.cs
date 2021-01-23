    static void Main(string[] args) {
    	System.Timers.Timer DatabaseTimer = new System.Timers.Timer();
    	//set the inteval to 20 seconds. Interval is in milliseconds so 20 sec = 20000 milisec
    	DatabaseTimer.Interval = 20000;
    	//start the timer
    	DatabaseTimer.Enabled = true;
    	//set the eventhandler, which is called every 20 seconds
    	DatabaseTimer.Elapsed += new System.Timers.ElapsedEventHandler(DatabaseTimer_Elapsed);
    }
    static void DatabaseTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e) {
    	//Your database query / printing here
    }
