    public static MvcHtmlString RenderTable(IEnumerable list, string id, string cssClass)
    {
        IEnumerable<dynamic> dynamicList = list.Cast<dynamic>();
        int x = dynamicList.Count();
        ...
    }
