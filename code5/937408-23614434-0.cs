    using Windows.Data.Xml.Dom;
    
    var uri = new Uri("http://dev.virtualearth.net/REST/v1/Locations/50,50?o=xml&key=Avu1gnmc6hy50Jsb-l3U_iTbKyOXI2wnsVS1tj7UMtwJxesB9WDZs_qyG0zKgpkZ");
    
    try
    { 
        var doc = await XmlDocument.LoadFromUriAsync(uri);
        var lc = doc.GetElementsByTagName("Locality");
    
        if (lc != null && lc[0] != null)
        {
            //lc[0].InnerText is the piece you want
        }
        else
        {
            //Element not in the XML
        }
    }
    catch
    {
        //Handle errors, e.g. no connectivity
    }
