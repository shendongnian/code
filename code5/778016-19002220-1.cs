	private List<MappingData> GetData(string filename)
	{
		var raw = new List<string[]>();
		var data = new List<MappingData>();
		string fullPath = GetFilePath(filename);
		using(var reader = new StreamReader(fullPath))
		{
			while (!reader.EndOfStream)
			{
				string line = reader.ReadLine();
				if (!String.IsNullOrWhiteSpace(line))
				{
					raw.Add(line.Split(','));
				}
			}
		}
		
		Func<int, MappingData> extract =
			n => new MappingData()
			{
				ColumnName = raw[0][n],
				Data = raw.Skip(1).Select(x => x[n]).ToList(),
			};
		
		data.Add(extract(0));
		data.Add(extract(1));
		data.Add(extract(2));
		
		return data;
	}
