	    string hexDate = DateToHex(DateTime.Now);
	 
        string sDate = string.Empty;
        for (int i = 0; i < hexDate.Length - 1; i += 2)       // Amended
        {
            string ss = hexDate.Substring(i, 2);
            int nn = int.Parse(ss, NumberStyles.AllowHexSpecifier);
		 
            string c = Char.ConvertFromUtf32(nn);
            sDate += c;
        }	 	
		
        CultureInfo provider = CultureInfo.InvariantCulture;
        CultureInfo[] cultures = { new CultureInfo("fr-FR") };
		
		
        return DateTime.ParseExact(sDate, "yyyyMMddHHmmss", provider);
		
