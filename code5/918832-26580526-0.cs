    JObject root = JObject.Parse(json);
    JObject prices = (JObject)root.SelectToken("response.prices");
    foreach (JProperty prop in prices.Properties())
    {
        if (prop.Name != "-1")
        {
            JToken value = prop.Value.SelectToken("6.0.current.value");
            if (value != null)
            {
                Console.WriteLine(prop.Name + ": " + value.ToString());
            }
        }
    }
