	public static class TextFileReader
	{
		public static BindingList<TextFileData> Read(string path)
		{
			var list = new BindingList<TextFileData>();
			
			using (StreamReader sr = new StreamReader(path))
            {
				while (sr.Peek() >=0)
				{
					String line = sr.ReadLine();
					string[] columns = line.Split('\t')
					
					list.Add(new TextFileData(columns[0], columns[1]));
				}
            }
			
			return list;
		}
	}
