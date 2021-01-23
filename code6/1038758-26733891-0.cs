            string originalDate = "09/25/2014 09:18:24";
            DateTime formattedDate;
            if (DateTime.TryParseExact(originalDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out formattedDate))
            {
                string output = formattedDate.ToString("yyyy-mm-dd", CultureInfo.InvariantCulture);
            }
