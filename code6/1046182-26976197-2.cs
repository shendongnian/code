        var json = await response.Content.ReadAsStringAsync();
        // Deserialize to a dynamic object
        var dynamicJson = JsonConvert.DeserializeObject<dynamic>(json);
        // Access keys as if they were members of a strongly typed class.
        // Binding will only happen at run-time.
        Console.WriteLine(dynamicJson.key1);
        Console.WriteLine(dynamicJson.key2);
