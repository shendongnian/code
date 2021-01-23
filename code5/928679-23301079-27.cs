	public void SerializeModel<T>(string fqfn, T entity)
	{
		var xmls = new XmlSerializer(entity.GetType());
		var writer = new StreamWriter(fqfn);
		xmls.Serialize(writer, entity);
		writer.Close();
	}
	
	public T DeserializeModel<T>(string fqfn)
	{
		var fs = new FileStream(fqfn, FileMode.Open);
		var xmls = new XmlSerializer(typeof(T));
		var r = (T) xmls.Deserialize(fs);
		fs.Close();
		return r;
	}
