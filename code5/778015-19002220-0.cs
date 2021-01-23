	private List<MappingData> GetData(string filename)
	{
		var data = new List<MappingData>();
		string fullPath = GetFilePath(filename);
		StreamReader reader = new StreamReader(fullPath);
		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			if (!String.IsNullOrWhiteSpace(line))
			{
				string[] values = line.Split(',');
				data.Add(new MappingData()
				{
					ColumnName = values.First(),
					Data = values.Skip(1).ToList(),
				});
			}
		}
		return data;
	}
