		public string CreaateXML(List<Room> room)
		{
		    var xmlnamespace = new XmlSerializerNamespaces();
		    xmlnamespace.Add(string.Empty, string.Empty);
		    XmlSerializer serializer = new XmlSerializer(typeof(List<Room>));
		    MemoryStream stream = new MemoryStream();
		    serializer.Serialize(stream, room, xmlnamespace);
		    return Encoding.UTF8.GetString(stream.ToArray());
		}
