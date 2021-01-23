    public static string GetXml(LatLonPoint data)
    {
      DataContractSerializer serializer = new DataContractSerializer(data.GetType());
      using ( MemoryStream stream = new MemoryStream() )
      {
        serializer.WriteObject(stream, data);
        byte[] bytes = stream.ToArray();
        return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
      }
    }
