        @{
            var routeValues = new RouteValueDictionary();
            routeValues.Add("sap-ie", "Edge");
            routeValues.Add("area", "");
            var attributes = new Dictionary<string, object>();
            attributes.Add("Id", "nav_abc");
        }
        @Html.ActionLink("Go to contact page", "Contact", routeValues, attributes)
    
