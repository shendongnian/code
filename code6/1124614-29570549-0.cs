    foreach (JToken token in model.Booster)
    {
        var array = token as JArray();
        if (array != null)
        {
            // The element is an array, so you can process its subelements here
        }
        else
        {
            // It's probably a string element
            string value = token.ToObject<string>();
        }
    }
