    public class DayInfo
    {
        public DayOfWeek CurrentDay{ get; set; }
    
        public bool IsWeekend
        {
            get
            {
                switch (CurrentDay)
                {
                    case DayOfWeek.Saturday:
                    case DayOfWeek.Sunday:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
