    string date = "01/08/2008";
    DateTime dt = Convert.ToDateTime(date);     //or       
    DateTime dt = DateTime.Parse(date, culture, System.Globalization.DateTimeStyles.AssumeLocal); //or       
    // create date time 2008-03-09 16:05:07.123
    DateTime dt = new DateTime(2008, 3, 9, 16, 5, 7, 123); //or       
    
