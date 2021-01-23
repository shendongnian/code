        public TimeSpan TimeSpan
        {
            get
            {
                return this.End.Date - this.Begin.Date; // use dates instead of original time stamps
            }
        }
