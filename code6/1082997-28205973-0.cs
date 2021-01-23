    JArray inputs = new JArray();
    JObject inputOne = new JObject(new JProperty("Age", "12"));
    inputOne.Add(new JProperty("BirthDate", "1234"));
    inputs.Add(new JObject(inputOne));
    r.Json.Add("inputs", jsonInputs);
