    private readonly XNamespace a = "http://www.w3.org/2005/Atom";
    private readonly XNamespace d = "http://schemas.microsoft.com/ado/2007/08/dataservices";
    private readonly XNamespace m = "http://schemas.microsoft.com/ado/2007/08/dataservices/metadata";
    List<KLList> lists = doc.Descendants(a + "entry").Where(element => element.Attribute(m + "etag") != null).Select(
        list => new KLList()
        {
            Id = list.Descendants(d + "Id").FirstOrDefault().Value,
            Title = list.Descendants(d + "Title").FirstOrDefault().Value,
            ListItemEntityTypeFullName = list.Descendants(d + "ListItemEntityTypeFullName").FirstOrDefault().Value,
            BaseType = (BaseType)Convert.ToInt32(list.Descendants(d + "BaseType").FirstOrDefault().Value),
            ListTemplateType = (ListTemplateType)Convert.ToInt32(list.Descendants(d + "BaseTemplate").FirstOrDefault().Value),
            RelativeUrl = list.Descendants(d + "ServerRelativeUrl").FirstOrDefault().Value
        }).ToList();
