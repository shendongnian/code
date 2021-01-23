    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Json;
    var jsonString = "{\"data\":[{\"id\":\"...\",\"from\":{\"category\":\"Local business\",\"name\":\"...\",\"id\":\"...\"},\"message\":\"...\",\"picture\":\"...\",\"likes\":{\"data\":[{\"id\":\"...\",\"name\":\"...\"},{\"id\":\"...\",\"name\":\"...\"}]}}]}";
    var jsonSerializer = new DataContractJsonSerializer(typeof(JsonRoot));
    JsonRoot json = null;
    using(var stream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString)))
    {
    	stream.Position = 0;
    	json = (JsonRoot)jsonSerializer.ReadObject(stream);
    }
