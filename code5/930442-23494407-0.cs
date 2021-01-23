    public Microsoft.SharePoint.Client.List getList(string name)
    {
        context.Load(context.Web.Lists);
        Microsoft.SharePoint.Client.List list = context.Web.Lists.GetByTitle(name);
        context.Load(list);
        context.ExecuteQuery();
        return list;
    }
