	public static class ExtensionMethods
	{
		public static DataTable ConvertToDataTable(this string input)
		{
			DataTable result = new DataTable();
			using (StringReader reader = new StringReader(input))
			{
				string[] columnNames = reader.ReadLine().Split(';'); //or other character
				foreach (var columnName in columnNames)
				{
					result.Columns.Add(columnName, typeof(string));
				}
				while (reader.Peek() > 0)
				{
					result.Rows.Add(reader.ReadLine().Split(';'));
				}
			}
			return result;
		}
	}
