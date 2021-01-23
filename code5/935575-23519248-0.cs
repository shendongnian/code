        var parameters = new Dictionary<string, string>(); // You pass this
        var url = "http://www.somesite.com?";
        int i = 0;
        foreach (var item in parameters)
        {
            url += item.Key + "=" + item.Value;
            url += i != parameters.Count ? "&" : string.Empty;
            i++;
        }
        return url;
