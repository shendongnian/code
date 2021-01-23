        public static String getWeekOrMonthFromDateDiff(DateTime first, DateTime second)
        {
            var span = second - first;
            if (span.Days <= 7)
                return span.Days + " day(s)";
            else
                return span.Days / 7 + " week(s)"; 
        }
