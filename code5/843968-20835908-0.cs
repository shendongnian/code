    DateTime start = DateTime.ParseExact("09162014_0830", "MMddyyyy_hhmm", CultureInfo.InvariantCulture);
    DateTime end = DateTime.ParseExact("11162014_0830", "MMddyyyy_hhmm", CultureInfo.InvariantCulture);
                   con.open()
                   var dt = new DataTable();
                   while (start <= end)
                   {
                       start = start.AddHours(1d);
                       string csvname = start.ToString("MMddyyyy_hhmm")+".csv";
                       cmd.CommandText = "select * from " + csvname ;
                       var tempdt = new DataTable();
                       tempdt.Load(cmd.ExecuteReader());
                       dt.Merge(tempdt);
                   }
                   con.close()
