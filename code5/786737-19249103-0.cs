    var vendorGroups = forecastHelpers
        .GroupBy(x => new { VendorNumber = x.VendorNumber, Division = x.PartDivision, Level = 1 })
        .GroupBy(x => new { VendorNumber = x.Key.VendorNumber }).OrderBy(x => x.Key.VendorNumber);
    
    foreach (var vendorGroup in vendorGroups)
    {
        System.Diagnostics.Debug.WriteLine("VendorNumber: " + vendorGroup.Key.VendorNumber);  
    
        foreach(var division in vendorGroup)
        {
           System.Diagnostics.Debug.WriteLine("Division: " + division.Key.division); 
           foreach (var part in division)
           {
               System.Diagnostics.Debug.WriteLine("Part: " + part.PartNumber); 
           } 
        }
    }
