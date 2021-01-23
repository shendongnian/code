        @{
            var routeValues = new RouteValueDictionary();
            routeValues.Add("sap-ie", "Edge");
            routeValues.Add("Id", "nav_abc");
    
            var attributes = new Dictionary<string, object>();
            attributes.Add("Id", "link1");
        }
        @Html.ActionLink("Go to contact page", "Contact", routeValues, attributes)
    
