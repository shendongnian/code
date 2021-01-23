    public static DateTime DateParse(string date)
            {
                date = date.Trim();
                if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date, new System.Globalization.CultureInfo("en-GB"));
                return new DateTime();
            }
