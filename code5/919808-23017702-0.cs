    var xdoc = XDocument.Load(memorystream);
    // Making it simple, grab the first
    var type = xdoc.Descendants(XName.Get("Type","http://schemas.datacontract.org/2004/07/Test.DataContracts.Global")).FirstOrDefault();
    var vendor = xdoc.Descendants(XName.Get("Vendor", "http://schemas.datacontract.org/2004/07/Test.DataContracts.Common")).FirstOrDefault();
    string path = "blah";
    if (type != null && type.Value == "0" && vendor != null && vendor.Value == "Ford")
    {
    	Console.WriteLine("File '{0}' indicates a female person that owns a vehicle of Ford.", path);
    }
    else
    {
    	Console.WriteLine("File '{0}' has no matches (female and Ford).", path);
    }
