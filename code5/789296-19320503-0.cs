    private void settingAttributeinZipppedXML(string ZipPath)
    {
    ZipFile zipFile = new ZipFile(Path.GetDirectoryName(Application.ExecutablePath) + "\\PATHDATA DT2.zip");
        zipFile.BeginUpdate();
        foreach (ZipEntry ze in zipFile)
        {
            if (ze.Name == "SOURCEDATACONFIG.XML")
            {
                using (StreamReader s = new StreamReader(zipFile.GetInputStream(ze)))
                {
                    XmlDocument XDoc = new XmlDocument();
                    XDoc.Load(s);
                    XmlNodeList NodeList = XDoc.SelectNodes(@"R/I");
                    foreach (XmlNode Node in NodeList)
                    {
                        XmlElement Elem = (XmlElement)Node;
                        Elem.SetAttribute("url", "12");
                    }
                    XDoc.Save("SOURCEDATACONFIG.XML");
                }
                zipFile.Add(ze.Name);
            }
        }
        zipFile.CommitUpdate();
    }
