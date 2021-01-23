    @{
        var sessionItems = Session.Keys.OfType<string>().ToDictionary (k => k, k => session[k]);	
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(sessionItems, Newtonsoft.Json.Formatting.Indented);
    }
    <pre>
        @Html.Raw(json);
    </pre>
