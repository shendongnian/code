        /// <summary>
        /// Converts a DateTime string to Date string. Also if Date is default value i.e. 01/01/0001
        /// then returns String.Empty.
        /// </summary>
        /// <param name="inputDate">Input DateTime property </param>
        /// <param name="showOnlyDate">Pass true to show only date.
        /// False will keep the date as it is.</param>
        /// <returns></returns>
        public static string ToString(this DateTime inputDate, bool showOnlyDate)
        {
            var resultDate = inputDate.ToString();
    
            if (showOnlyDate)
            {
                if (inputDate == DateTime.MinValue)
                {
                    resultDate = string.Empty;
                }
                else
                {
                    resultDate = inputDate.ToString("dd-MMM-yyyy");
                }
            }
            return resultDate;
        }
