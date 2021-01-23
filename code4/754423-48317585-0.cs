    /// <summary>
    /// Returns DateTime?
    /// Excel dates are double values, and sometimes, they're typical dd/mm/yyyy dates.
    /// This function handles both possibilities, and the possibility of a blank date input. 
    /// /// 
    /// </summary>
    /// <param name="inputDate"></param>
    /// <returns></returns>
    private static DateTime? ResolveExcelDateInput(string inputDate)
    {
        double incomingDate = 0;
        DateTime incomingDateDate = new DateTime();
        // If the incoming date is a double type, parse it into DateTime
        if (Double.TryParse(inputDate, out incomingDate))
        {
            return DateTime.FromOADate(incomingDate);
        }
        // IF the incoming date value is a date type, parse it.
        var parseDateResult = DateTime.TryParse(inputDate, out incomingDateDate);
        if(parseDateResult)
        {
            // If the parse is successful return the date
            return incomingDateDate;
        }
        else
        {
            // If the parse isn't successful; check if this a blank value and set to a default value.
            if(string.IsNullOrWhiteSpace(inputDate))
            {
                return new DateTime(1901, 1, 1);
            }
            else
            {
                // Otherwise return null value so that is then handled by the validation logic.
                // log a validation result because inputDate is likely an invalid string value that has nothing to do with dates.
                return null;
            }
        }
    }
