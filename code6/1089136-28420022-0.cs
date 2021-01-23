    public void Put([FromBody] JObject jsonData)
    {
        JToken token;
        if (jsonData.TryGetValue("phone", out token))
        {
            var value = (string)token;
            if (value == null)
            {
                // phone property exists but has null value
            }
            else
            {
                // phone property exists and has non-null value
            }
        }
        else
        {
            // phone property does not exist
        }
    }
