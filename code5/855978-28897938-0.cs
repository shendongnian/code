    public static JObject mergeJsonObjects(List<JObject> objects) {
            
        JObject json = new JObject();
        foreach(JObject JSONObject in objects) {
            foreach(var property in JSONObject) {
                string name = property.Key;
                JToken value = property.Value;
                json.Add(property.Key, property.Value);
            }
        }
        return json;
    }
