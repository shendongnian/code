        namespace Sample.WpfExample
        {
        public class TickerC : INotifyPropertyChanged
        {
            public TickerC()
            {
                Timer timer = new Timer();
                timer.Interval = 1000; // 1 second updates
                timer.Elapsed += timer_Elapsed;
                timer.Start();
            }
    
            public DateTime Now
            {
                get { return DateTime.Now; }
            }
    
            void timer_Elapsed(object sender, ElapsedEventArgs e)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Now"));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
