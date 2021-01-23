            System.Globalization.CultureInfo cultureinfo =
            new System.Globalization.CultureInfo(System.Globalization.CultureInfo.CurrentCulture.Name);
    		String stringDate="Jul 29 2014 12:00AM";
    		DateTime date=DateTime.Parse(stringDate,cultureinfo);
    		Console.Write(date.ToString());
