    // Make sure the JSON is well formatted
    string formattedJson = JObject.Parse(message).ToString();
    
    // Define the keys of the values to be masked
    string[] maskedKeys = {"mask1", "mask2"};
    // Loop through each key
    foreach (var key in maskedKeys)
    {
        string original_pattern = string.Format("(\"{0}\": )(\"?[^,\\r\\n]+\"?)", key);
        string masked_pattern = "$1\"censored\"";
        Regex pattern = new Regex(original_pattern);
        formatted_json = pattern.Replace(formatted_json, masked_pattern);
    }
    
    // Parse the masked string
    var maskedMessage = JsonConvert.DeserializeObject<dynamic>(formatted_json);
