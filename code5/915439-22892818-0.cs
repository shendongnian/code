    DateTime date;
    if (DateTime.TryParseExact(inputDate.Text.Trim(), "M/dd/yyyy", enUS, DateTimeStyles.None, out date))
       {
       	//Action to use date;
       }
    else
       {
       	//action to tell user that inputDate.Text is not date string as expected
       }
