     JObject json = JsonConvert.DeserializeObject<JObject>(jsonResponse);
     foreach (Dictionary<string, object> item in data["Elements"])
     {
        foreach (string val in item.Values) {
            Console.WriteLine(val);
        }
      }
