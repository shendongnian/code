    public class CalendarEvent
    {
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        
        public SetStartAndEndDates(DateTime start, DateTime end)
        {
            if (start <= end)
            {
                StartDate = start;
                EndDate = end;
            }
            else
            {
                throw new InvalidDates();
            }
        }
        public bool IsValidEndDate(DateTime end)
        {
            return StartDate <= end;
        }
        public bool IsValidStartDate(DateTime start)
        {
            return start <= EndDate;
        }
        public bool IsValidStartAndEndDate(DateTime start, DateTime end)
        {
            return start <= end;
        }
    }
