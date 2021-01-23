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
