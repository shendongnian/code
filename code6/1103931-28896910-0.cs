        public class Task
        {
            public DateTime Start;
            public TimeSpan Duration;
            public TimeSpan GetWorkingDays()
            {
                int days = (int)Math.Floor(this.Duration.TotalHours/8);
                int hours = (int)Math.Floor(this.Duration.TotalHours - days * 8);
                return new TimeSpan(days, hours, 0, 0);
            }
        }
