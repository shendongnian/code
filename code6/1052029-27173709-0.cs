    DateTime dateTime = DateTime.ParseExact(date.Trim(), "M/d/yyyy H:mm:ss", CultureInfo.InvariantCulture);
            if((dateTime.Month == 1 || dateTime.Month == 2 || dateTime.Month == 3) && dateTime.Year == 2012)
            {
                if (sub == "AM") 
                { 
                   AM[0]++; 
                }
            }
