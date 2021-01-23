    string dateInput = "January 09, 2012";
    DateTime dt = DateTime.ParseExact(dateInput, "MMMM dd, yyyy", 
    System.Globalization.CultureInfo.InvariantCulture, 
    System.Globalization.DateTimeStyles.None);
    string dateOutput = dt.ToString("MMddyyyy");
