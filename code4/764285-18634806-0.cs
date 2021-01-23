    DateTime LastDayOfYear(DateTime date)
        {           
            DateTime newdate = new DateTime(date.Year + 1, 1, 1);
            //Substract one year
            return newdate.AddDays(-1);
        }
    //Here calling the function 
    DateTime current_time = LastDayOfYear(DateTime.Now); // 05,Sep ,2013
    // It returned 31, Dec, 2013
