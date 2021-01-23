    XDocument xdoc;
    using (Stream stream = storage.OpenFile("APPSDATA.xml", FileMode.Open, FileAccess.Read))
    {
        xdoc = XDocument.Load(stream, LoadOptions.None);
    }
    var listapp = from c in xdoc.Descendants("Ungdung") select c;
    foreach (XElement app in listapp)
    {
        var xElement = app.Element("Name");
        if (xElement != null)
            progressIndicator.Text = "Checking " + xElement.Value + "...";
        var element = app.Element("Id");
        if (element != null)
        {
            var appId = element.Value;
            var appVersion = await GetAppsVersion(appId);
            app.Element("Version").Value = appVersion.ToString();
        }
    }
    using (Stream stream = storage.OpenFile("APPSDATA.xml", FileMode.Truncate, FileAccess.Write))
    {
        xdoc.Save(stream);
    }
