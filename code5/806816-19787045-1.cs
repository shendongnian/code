    CultureAndRegionInfoBuilder cib = null;
    try
    {
        // Create a CultureAndRegionInfoBuilder object named "ro-MD".
        cib = new CultureAndRegionInfoBuilder(
                                "ro-MD", CultureAndRegionModifiers.None);
        // Populate the new CultureAndRegionInfoBuilder object with culture information.
        CultureInfo ci = new CultureInfo("ro-RO");
        cib.LoadDataFromCultureInfo(ci);
        // Populate the new CultureAndRegionInfoBuilder object with region information.
        RegionInfo ri = new RegionInfo("RO");
        cib.LoadDataFromRegionInfo(ri);
        var filePath = "ro-MD.xml";
        if (File.Exists(filePath))
            File.Delete(filePath);
        // Save as XML
        cib.Save(filePath);
        // TODO: modify the XML
        var roMd = CultureAndRegionInfoBuilder.CreateFromLdml(filePath);
        try
        {
            CultureAndRegionInfoBuilder.Unregister("ro-MD");
        }
        catch (Exception)
        {
            //throw;
        }
        // Register the custom culture.
        roMd.Register();
        // Display some of the properties of the custom culture.
        var riMd = new RegionInfo("ro-MD");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
    }
