        public ObservableCollection<DateTime> Available { get; set; } 
        public ObservableCollection<TimeRange> Bookings { get; set; }
        public TimeBookingsViewModel()
        {
            Available = new ObservableCollection<DateTime>(Enumerable.Range(8, 11).Select(x => new DateTime(2013, 1, 1).AddHours(x))); 
            
            Bookings = new ObservableCollection<TimeRange>(); 
            
            Bookings.Add(new TimeRange(8, 0, 9, 50) {Base = TimeSpan.FromHours(8)});
            Bookings.Add(new TimeRange(10, 0, 11, 00) { Base = TimeSpan.FromHours(8) });
            Bookings.Add(new TimeRange(12, 00, 13, 30) { Base = TimeSpan.FromHours(8) });
        }
    }
