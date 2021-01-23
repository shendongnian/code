    private XmlNode GetListItems(string listTitle)
    {
        var client = new Lists.Lists();
        client.Url = webUri + "/_vti_bin/Lists.asmx";
        return client.GetListItems(listTitle, string.Empty, null, null, string.Empty, null, null);
    }
