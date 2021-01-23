     public static bool IsValidDate(string value, string[] dateFormats)
        {
            DateTime tempDate;
            bool validDate = DateTime.TryParseExact(value, dateFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None, ref tempDate);
            if (validDate)
                return true;
            else
                return false;
        }
