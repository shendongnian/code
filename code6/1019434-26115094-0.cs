    var xmlFile = HttpContext.Current.Server.MapPath("~/App_Data/Theme.xml");
    XDocument xmlDoc = XDocument.Load(xmlFile);
    var xmlPage = (from page in xmlDoc.Descendants()
                  where page.Name.LocalName == "page"
                        && page.Attribute("name").Value == pageName
                  select page).FirstOrDefault();
    if (xmlPage != null)
    {
        //do what you need
    }
