        public DateTime setBusinessDay(DateTime dt)
        {
        	if (dt.DayOfWeek == DayOfWeek.Saturday)
        		return dt.AddDays(-1);
    		else if (dt.DayOfWeek == DayOfWeek.Sunday)
    			return dt.AddDays(-2);
    		else
    			return dt;
        }
    
        public MainWindow()
        {
            InitializeComponent();
            DateTime d_temp = DateTime.Today;
    
    		dp1.SelectedDate = setBusinessDay(new DateTime(d_temp.Year, d_temp.Month, DateTime.DaysInMonth(d_temp.Year, d_temp.Month)));
        }
