    static void SaveSettings(GraphSettings settings, string file)
    {
      var serializer = new XmlSerializer(typeof(GraphSettings));
    
      using (var stream = File.Create(file))
      {
        serializer.Serialize(stream, settings);
    
        stream.Flush();
        stream.Close();
      }
    }
    
    static GraphSettings LoadSettings(string file)
    {
      var serializer = new XmlSerializer(typeof(GraphSettings));
      using (var stream = File.Open(file, FileMode.Open, FileAccess.Write, FileShare.Read))
      {
        var settings = serializer.Deserialize(stream) as GraphSettings;
        stream.Close();
        return settings;
      }
    }
