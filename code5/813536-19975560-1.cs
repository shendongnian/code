    string key = null;
    string value = null;
    
    foreach(var item in inner)
    {
        JProperty questionAnswerDetails = item.First.Value<JProperty>();
    
        var questionAnswerSchemaReference = questionAnswerDetails.Name;
    
        var propertyList = (JObject)item[questionAnswerSchemaReference];
    
        questionDetails = new Dictionary<string, object>();
        foreach (var property in propertyList)
        {
             key = property.Key;
             value = property.Value.ToString();
        }
        
        questionDetails.Add(key, value);               
    }
