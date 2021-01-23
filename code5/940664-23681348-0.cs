    var xdoc = XDocument.Parse("...");
    var xname = XName.Get("BusinessID", "http://schemas.datacontract.org/2004/07/BG.Bus.Mobile.Classes");
    var businessId = xdoc.Descendants(xname).FirstOrDefault();
    businessId.Value = "New value";
    string result = xdoc.ToString(); 
