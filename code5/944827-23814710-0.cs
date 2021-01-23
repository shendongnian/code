    static public bool ValidateParsianDate(string date)
    {
        bool status = true;
    
        try
        {
            PersianCalendar persianCalendar = new PersianCalendar();
            var dateParts = date.Split(new char[] { '/' }).Select(d=> int.Parse(d)).ToArray();
            var date = persianCalendar.ToDateTime(dateParts[2], dateParts[1], dateParts[0], 0, 0,0,0, /*8 era of year here **/);
     }
        catch (Exception ex)
        {
            string msg = ex.Message;
            status = false;
        }
    
        return status;
    }
