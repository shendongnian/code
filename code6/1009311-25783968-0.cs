    [Table]
        public class HistoryDB
        {
            [Column(IsPrimaryKey = true)]
            public int Id { get; set; }
    
            [Column(CanBeNull = false)]
            public DateTime Date
            { get; set; }
    
            [Column(CanBeNull = false)]
            public DateTime Time
            { get; set; }
    
            [Column(CanBeNull = false)]
            public String Zone
            { get; set; }
    
            [Column(CanBeNull = false)]
            public String Floor
            { get; set; }
    
            [Column(CanBeNull = false)]
            public double location_latitude
            { get; set; }
    
            [Column(CanBeNull = false)]
            public double location_longtitud
            { get; set; }
    
        }
    	
            public void addDataDB()
            {
                using (HistoryDataContext historylog = new HistoryDataContext(HistoryDataContext.DBConnectionString))
                {
                    HistoryDB hdb = new HistoryDB
                    {
                        Id = 0,
                         Date = DateTime.Today,
                        Time = DateTime.Now,
                        Zone = "Zone",
                        Floor = "Floore",
                        location_latitude = 00.00,
                        location_longtitud = 00.00
                    };
                    historylog.history.InsertOnSubmit(hdb);
                    historylog.SubmitChanges();
                    GetHistoryLog();
    
                }
            }
