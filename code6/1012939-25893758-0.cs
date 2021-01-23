     public string FormatDate(string inputDate)
        {
            System.DateTime strDate;
            if (System.DateTime.TryParseExact(inputDate, "yyyy-MM-ddTHH:mm:ss", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out strDate))
            {
                return strDate.ToString("yyyy-MM-dd");
            }
            return "INVALID DATE";
        }
