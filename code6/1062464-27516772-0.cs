    using NodaTime;
        DateTime EventDT;
        LocalDateTime LocalizedEventDT;
        Period TimeLeft;
        DispatcherTimer IMTSCountdown;   
        public MainWindow()
        {
            InitializeComponent();
            // Start with a date and time
            EventDT = Convert.ToDateTime("09/12/2016 10:00AM");
            // Localize it
            LocalizedEventDT = new LocalDateTime(
                EventDT.Year, EventDT.Month, 
                EventDT.Day, EventDT.Hour, 
                EventDT.Minute, 0);
            // timer
            IMTSCountdown = new DispatcherTimer();
            IMTSCountdown.Interval = TimeSpan.FromMilliseconds(1000);
            IMTSCountdown.Tick += IMTSCountdown_Tick;
            IMTSCountdown.Start();
        }
        void IMTSCountdown_Tick(object sender, EventArgs e)
        {
            DateTime dt_Now = DateTime.Now;
            // find out how much time is between now and the future date (new)
            TimeLeft = Period.Between(new LocalDateTime(
                dt_Now.Year, dt_Now.Month, dt_Now.Day, dt_Now.Hour, 
                dt_Now.Minute, dt_Now.Second), LocalizedEventDT);
            Countdown_YearMonth.Content = " " + 
                TimeLeft.Years + " Year  " + TimeLeft.Months + " Months ";
            Countdown_DayHour.Content = " " + 
                TimeLeft.Days + " Days  " + TimeLeft.Hours + " Hours ";
            Countdown_MinSec.Content = " " + TimeLeft.Minutes + 
                " Minutes   " + TimeLeft.Seconds + " Seconds ";
        }
