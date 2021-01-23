        Put this method in class form or in the same form pass the string date format that you read it gives you date difference
        public static double GetDateDiff(string d1, string d2)
        {
            double result = 0.0;
            DateTime MyDate1 = Convert.ToDateTime(d1);
            DateTime MyDate2 = Convert.ToDateTime(d2);
            result = ((MyDate1 - MyDate2).TotalDays);
            return result;
        }
