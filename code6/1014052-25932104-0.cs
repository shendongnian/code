    protected void Page_Load(object sender, EventArgs e)
        {
    
        System.Timers.Timer aTimer = new System.Timers.Timer();
        aTimer.Elapsed+=new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval=600000;//10 min timer
        aTimer.Enabled=true;
    }
 
    DataTable table = new DataTable();
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
         {
            // code to save data in datatable;
           //like
        table.Clear();//Refresh the table
    	table.Columns.Add("name", typeof(string));
        table.Rows.Add(TextBox1.Text);//This is just sample code
         }
