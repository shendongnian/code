    public static DateTime ToDate(this object obj)
        {
            string dateString = Convert.ToString(obj);
            string format = "dd/MM/yyyy";
            return DateTime.ParseExact(dateString, format,
                CultureInfo.InvariantCulture);
        }
