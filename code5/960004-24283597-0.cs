    System.Globalization.CultureInfo[] cinfo = System.Globalization.CultureInfo.GetCultures(System.Globalization.CultureTypes.AllCultures & ~System.Globalization.CultureTypes.NeutralCultures);
    System.Globalization.RegionInfo ri = null;
    foreach (System.Globalization.CultureInfo cul in cinfo)
    {	
    	try
    	{
    		ri = new System.Globalization.RegionInfo(cul.Name);
    		Console.WriteLine(cul.TwoLetterISOLanguageName+"-"+ri.TwoLetterISORegionName);
    	}
    	catch
    	{
    		continue;
    	}
    }
