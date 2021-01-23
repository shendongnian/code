    AnalyticsLogs analyticsLogs = new AnalyticsLogs();
    Analytics analytics = new Analytics();
    analytics.Action = "Action test XML";
    analytics.Category = "Category test XML";
    analytics.Label = "Label test";
    analytics.Value = 47950494;
    analytics.Timestamp = DateTime.Now;
    analyticsLogs.Add(analytics);
    var serializer = new RestSharp.Serializers.XmlSerializer();
    var xml = serializer.Serialize(analyticsLogs);
    var obj = Deserialize<AnalyticsLogs>(xml);
    static string Serialize<T>(T value) {
        XmlMediaTypeFormatter formatter = new XmlMediaTypeFormatter();
        // formatter.UseXmlSerializer = true;
        // Create a dummy HTTP Content.
        Stream stream = new MemoryStream();
        var content = new StreamContent(stream);
        /// Serialize the object.
        formatter.WriteToStreamAsync(typeof(T), value, stream, content, null).Wait();
        // Read the serialized string.
        stream.Position = 0;
        return content.ReadAsStringAsync().Result;
    }
    static T Deserialize<T>(string str) where T : class {
        XmlMediaTypeFormatter formatter = new XmlMediaTypeFormatter();
        // formatter.UseXmlSerializer = true;
        // Write the serialized string to a memory stream.
        Stream stream = new MemoryStream();
        StreamWriter writer = new StreamWriter(stream);
        writer.Write(str);
        writer.Flush();
        stream.Position = 0;
        // Deserialize to an object of type T
        return formatter.ReadFromStreamAsync(typeof(T), stream, null, null).Result as T;
    }
