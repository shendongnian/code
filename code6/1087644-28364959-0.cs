    public class ClubViewModel
    {
        public int ClubId { get; set; }
        public string Organisation { get; set; }
        public IList<CalendarEntryViewModel> CalendarEntries { get; set; } // <--- a list of them      
    }
