    public class Time
    {
    
        public Time() { }
    
        /// <summary>
        /// the hour
        /// </summary>
        public int Hour
        {
            get;
            set;
        }
    
        /// <summary>
        /// the minuets
        /// </summary>
        public int Minutes
        {
            get;
            set;
        }
    
        /// <summary>
        /// the time in format hh:mm
        /// </summary>
        public string Value
        {
            get { return String.Format("{0:00}:{1:00}", Hour, Minutes); }
            set 
            { 
                string[] spl = value.Split(':');
                Hour = Int32.Parse(spl[0]);
                Minutes = Int32.Parse(spl[1]);
            }
        }
    }
