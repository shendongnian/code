    public class DateExample
    {
        private DateTime _dt;
        public string dt
        {
            get
            {
                return _dt.ToString("hh:mm:ss tt",
                    System.Globalization.CultureInfo.InvariantCulture);
                // Displays 06:09:01 PM 
            }
            private set { }
        }
    }
