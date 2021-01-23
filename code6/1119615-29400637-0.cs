    object result = field.Value;
    if (field.Value.GetType() == typeof(JObject))
    {
          JToken token = (JToken)field.Value;
          result = token.ToObject(property.PropertyType, JsonSerializer.Create(JsonUtility.Settings));
    }
    else
    {
          result = Convert.ChangeType(result, property.PropertyType);
    }
    property.SetValue(comInstance, result); 
