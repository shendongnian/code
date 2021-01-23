    DateTime temp;
    DateTime.TryParse(input, CultureInfo.CurrentUICulture, DATE_TIME_STYLES, out temp);
    
    if (temp.Year == DateTime.Now.Year)
    {
        if (!input.Contains(DateTime.Now.Year))
        {
            if (temp.Days != int.Parse(DateTime.Now.Year.ToString().SubString(2)))
            {
                 // my god that's gross but it tells you if the day is equal to the last two
                 // digits of the current year, if that's the case make sure that value occurs
                 // twice, if it doesn't then we know that no year was specified
            } 
        }
    }
