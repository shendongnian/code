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
            if (showOnlyDate)
            {
                string returnString;
                if (inputDate == DateTime.MinValue)
                {
                    returnString = "N/A";
                }
                else
                {
                    returnString = inputDate.ToString("dd-MMM-yyyy");
                }
                return returnString;
            }
            return inputDate.ToString();
        }
