    public class DateRange
    {
        public DateRange(DateTime start, DateTime end)
        {
            if (start>end)
            {
                throw new ArgumentException("Start date time cannot be after end date time");
            }
            Start = start;
            End = end;
        }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public static bool operator ==(DateRange range1, DateRange range2)
        {
            if (range1.Start == range2.Start && range1.End == range2.End)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(DateRange range1, DateRange range2)
        {
            return !(range1 == range2);
        }
    }
