    private bool CheckForUpdateAvailable()
    {
        Uri updateLocation = ApplicationDeployment.CurrentDeployment.UpdateLocation;
    
        //Used to use the Clickonce API but we've uncovered a pretty serious bug which results in a COMException and the loss of ability
        //to check for updates. So until this is fixed, we're resorting to a very lo-fi way of checking for an update.
    
        WebClient webClient = new WebClient();
        webClient.Encoding = Encoding.UTF8;
        string manifestFile = webClient.DownloadString(updateLocation);
    
        //We have some garbage info from the file header, presumably because the file is a .application and not .xml
        //Just start from the start of the first tag
        int startOfXml = manifestFile.IndexOfAny(new[] { '<' });
        manifestFile = manifestFile.Substring(startOfXml);
    
        Version version;
    
        XmlDocument doc = new XmlDocument();
    
        //build the xml from the manifest
        doc.LoadXml(manifestFile);
    
        XmlNodeList nodesList = doc.GetElementsByTagName("assemblyIdentity");
        if (nodesList == null || nodesList.Count <= 0)
        {
            throw new XmlException("Could not read the xml manifest file, which is required to check if an update is available.");
        }
    
        XmlNode theNode = nodesList[0];
        version = new Version(theNode.Attributes["version"].Value);
    
        if (version > ApplicationDeployment.CurrentDeployment.CurrentVersion)
        {
            // update application
            return true;
        }
        return false;
    }
