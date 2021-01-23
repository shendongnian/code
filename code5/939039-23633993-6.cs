    public struct DateValue
    {
        public DateValue(DateTime date, double val)
            : this()
        {
            this.Date = date;
            this.Value = val;
        }
        public DateTime Date { get; set; }
    }
