     //this is parsing the datetime using Swedish format
     string theCulture = "sv-SE";
     string localDts = "2013-11-25 06:25";
     DateTime localDt = DateTime.Parse(localDts, System.Globalization.CultureInfo.CreateSpecificCulture(theCulture));
            
