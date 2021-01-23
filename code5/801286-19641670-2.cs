      private static String Interval(DateTime start, DateTime end)
        {
            if (end <= start)
            {
                throw new Exception("Invalid interval");
            }
            int days = 0;
            int months = 0;
            int years = 0;
            DateTime temp = start;
            while (start.AddYears(years) <= end)
            {
                ++years;
            }
            --years;
            temp = temp.AddYears(years);
            while (temp.AddMonths(months) <= end)
            {
                ++months;
            }
            --months;
            temp = temp.AddMonths(months);
            while (temp.AddDays(days) <= end)
            {
                ++days;
            }
            --days;
            StringBuilder result = new StringBuilder();
            if (years > 0)
            {
                result.AppendFormat("{0}Y ", years);
            }
            if (months > 0)
            {
                result.AppendFormat("{0}M ", months);
            }
            if (days > 0)
            {
                result.AppendFormat("{0}D", days);
            }
            return result.ToString();
        }
