            DateTime a = new DateTime(2013,11, 18, 02, 00, 00);
            DateTime b = new DateTime(2013, 11, 20, 03, 30, 00);
            double days = 0;
            TimeSpan duration = b - a;
           
            if (duration.TotalDays > 0 && duration.TotalDays < 1)
            {
                days = 1;
            }
            else if (duration.TotalHours > 0)
            {
                days = Math.Ceiling(Convert.ToDouble(duration.TotalHours) / 24);
            }
