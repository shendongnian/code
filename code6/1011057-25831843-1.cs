    public class Room
    {
        private List<FromToDateTime> _intervals;
        public List<FromToDateTime> Intervals
        {
            get
            {
                return _intervals;
            }
            set
            {
                _intervals = value;
            }
        }
        public Room()
        {
            Intervals = new List<FromToDateTime>();
        }
        public bool addInterval(FromToDateTime newInterval)
        {
            foreach (FromToDateTime interval in Intervals)
            {
                if (newInterval.Start < interval.End && interval.Start < newInterval.End)
                {
                    return false;
                }
            }
            Intervals.Add(newInterval);
            return true;
        }
    }
