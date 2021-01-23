    public class FromToDateTime
    {
        private DateTime _start;
        public DateTime Start
        {
            get
            {
                return _start;
            }
            set
            {
                _start = value;
            }
        }
        private DateTime _end;
        public DateTime End
        {
            get
            {
                return _end;
            }
            set
            {
                _end = value;
            }
        }
        public FromToDateTime(DateTime start, DateTime end)
        {
            Start = start;
            End = end;
        }
    }
