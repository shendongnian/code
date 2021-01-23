    var parameters = new List<string>();
    foreach (var item in List)
    {
        parameters.Add(item.Name + "=" + item.Value.ToString());
    }
    
    string url = "http://www.somesite.com?" + String.Join("&", parameters);
