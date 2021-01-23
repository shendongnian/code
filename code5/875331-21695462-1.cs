    string json = File.ReadAllText("settings.json");
    dynamic jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject(json);
    jsonObj["Bots"][0]["Password"] = "new password";
    string output = Newtonsoft.Json.JsonConvert.SerializeObject(jsonObj, Newtonsoft.Json.Formatting.Indented);
    File.WriteAllText("settings.json", output);
