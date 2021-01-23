    System.Globalization.CultureInfo cultureinfo =
         new System.Globalization.CultureInfo("en-US");
        prepayException.StartDate = DateTime.Parse(PPEx.StartDate.ToString(), cultureinfo);
     prepayException.EndDate = DateTime.Parse(PPEx.EndDate.ToString(), cultureinfo);
 
