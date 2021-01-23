    string currentAppVer = string.Empty;
    var xmlReaderSettings = new XmlReaderSettings { XmlResolver = new XmlXapResolver() };
    using (var xmlReader = XmlReader.Create("WMAppManifest.xml", xmlReaderSettings))
    {
         xmlReader.ReadToDescendant("App");
         currentAppVer = xmlReader.GetAttribute("Version").Replace(".", "");
    }
    
    try
    {
         if ((Convert.ToInt32(currentAppVer)) < (Convert.ToInt32(response.appVersion)))
         {
              MarketplaceDetailTask marketplaceDetailTask = new MarketplaceDetailTask();
              marketplaceDetailTask.ContentIdentifier = App.appContentIdentifier;
              marketplaceDetailTask.ContentType = MarketplaceContentType.Applications;
              marketplaceDetailTask.Show();
              Application.Current.Terminate();
         }
    }
    catch (Exception ex)
    { }
