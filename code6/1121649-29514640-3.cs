	public static SerializableType LoadFromXmlFile(string filename)
	{
		using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read, 1024))
		{
			using (var reader = XmlDictionaryReader.Create(stream))
			{
				var serializer = new DataContractSerializer(typeof(SerializableType));
				return (SerializableType)serializer.ReadObject(reader);
			}
		}
	}
