        /// <summary>
        /// Return a date formatted MonthDay depending of the current application cutlure
        /// </summary>
        /// <param name="datetime">The datetime to parse</param>
        /// <returns>A Month day string representation</returns>
        public static string ToMonthDay(this DateTime datetime)
        {
            // Get the current culture of the application
            var culture = new CultureInfo(Thread.CurrentThread.CurrentCulture.Name);
            // Get the format depending of the culture of the application
            var output = culture.DateTimeFormat.ShortDatePattern;
            // Remove the Year from from the date format
            var format = output.Replace("Y", "").Replace("y", "");
            // Remove any character before or after in the text string which is not a number
            Regex rgx = new Regex("^[^a-zA-Z0-9]|[^a-zA-Z0-9]$");
            format = rgx.Replace(format, "");
            return datetime.ToString(format);
        }
    
