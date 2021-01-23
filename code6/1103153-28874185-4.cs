    internal class ResultEntry
    {
        public ResultEntry(DateTime dateTime, int minutesOn)
        {
            DateTime = dateTime;
            this.MinutesOn = minutesOn;
        }
        public DateTime DateTime { get; set; }
        public int MinutesOn { get; set; }
    }
