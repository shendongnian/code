    		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xml"></param>
		/// <exception cref="InvalidOperationException"></exception>
		/// <returns></returns>
		public static T Deserialize<T>(XmlNode xml)
		{
			// Assuming xml is an XML document containing a serialized object.
			XmlNodeReader reader = new XmlNodeReader(xml);
			// When we get the xml, it is usually a sub element that can have a different name, than the type name. Therefore look for the name
			XmlSerializer ser = new XmlSerializer(typeof(T));
			object obj = ser.Deserialize(reader);
			// Then you just need to cast obj into whatever type it is eg:
			return (T)obj;
		}
		/// <summary>
		/// Serializes without removing namespace and using the specified encoding
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <param name="encoding"></param>
		/// <returns></returns>
		/// <exception cref="InvalidOperationException">When the object can not be serialized to xml</exception>
		public static XmlDocument Serialize<T>(T obj, Encoding encoding)
		{
			XmlSerializer ser = GetSerializer(obj.GetType());
			using (MemoryStream stream = new MemoryStream())
			using (XmlTextWriter writer = new XmlTextWriter(stream, encoding))
			{
				ser.Serialize(writer, obj);
				XmlDocument doc = new XmlDocument();
				writer.Flush();
				stream.Position = 0;
				doc.Load(stream);
				return doc;
			}
		}
