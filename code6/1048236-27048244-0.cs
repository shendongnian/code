    var obj = JObject.Parse(json);
    var responses = new Responses { Model = new List<Model>() };
            
    foreach (var child in obj.Values())
    {
        if (child is JArray)
        {
            responses.Model = child.ToObject<List<Model>>();
            break;
        }
        else
            responses.Model.Add(child.ToObject<Model>());
    }
