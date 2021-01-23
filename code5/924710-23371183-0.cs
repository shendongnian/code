    client.GetCompleted += async(o1, e1) =>
    {
        if (e1.Error != null)
        {
            return;
        }
        var result1 = (IDictionary<string, object>)e1.GetResultData();
    
    
        JObject jobj1 = JObject.Parse(e1.GetResultData().ToString());
        JArray x1 = (JArray)jobj1["data"];   
    
    };
    await client.GetTaskAsync("me/permissions?");
