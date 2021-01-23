    [DebuggerDisplay("{Name}")]
    public class Rule
    {
        public string Name;
        public int MaxAge;
        public DateTime StartDate;
        public DateTime EndDate;
    #if DEBUG
        private string DateRange
        {
            get { return StartDate.ToString("dd/MM/yyyy") + " - "+
                         EndDate.ToString("dd/MM/yyyy");
            } 
        }
    #endif
    }
