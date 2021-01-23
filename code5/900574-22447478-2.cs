    public class DayOfWeekHoliday : IHoliday
    {
        public int Nth { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Month { get; set; }
    
        public bool isHoliday(DateTime date)
        {
            return date.Month == Month && date.DayOfWeek == DayOfWeek && (date.Day - 1) / 7 == (Nth - 1);
        }
    } 
