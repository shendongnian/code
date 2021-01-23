    public class TimeBookingsViewModel
    {
        public ObservableCollection<DateTime> Available { get; set; } 
        public ObservableCollection<TimeRange> Bookings { get; set; }
        public TimeBookingsViewModel()
        {
            Available = new ObservableCollection<DateTime>(Enumerable.Range(0, 23).Select(x => new DateTime(2013,1,1).AddHours(x)));
            Bookings = new ObservableCollection<TimeRange>();
            Bookings.Add(new TimeRange(1, 0, 3, 50));
            Bookings.Add(new TimeRange(4, 20, 5, 00));
            Bookings.Add(new TimeRange(6, 00, 6, 30));
            Bookings.Add(new TimeRange(6, 45, 9, 00));
        }
    }
