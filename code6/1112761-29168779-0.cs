    JArray jInner = new JArray();
    JObject container = new JObject();
    JProperty jTitle = new JProperty("title", category);
    JProperty jDescription = new JProperty("description", "this is the description");
    JProperty jContent = new JProperty("content", content);
    container.Add(jTitle);
    container.Add(jDescription);
    container.Add(jContent);
    jInner.Add(container);
