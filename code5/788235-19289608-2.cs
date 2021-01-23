    public static string GetLink(this HtmlHelper helper, RouteData routeData)
    {
        foreach(var item in routeData.Values)
        {
            if(!item.Key.Equals("controller") && !item.Key.Equals("action"))
            {
                var routeValues = new RouteValueDictionary(item);
                var url = helper.ActionLink("text link", "myAction", "myController", routeValues, null);
            }
        }
    }
