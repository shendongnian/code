    static void Main(string[] args)
		{
			int[] sourceData = {0,0,0,0,0};
			DataTable source = new DataTable();
			source.Columns.Add("ColOne");
			source.Columns.Add("ColTwo");
			source.Columns.Add("ColThree");
			source.Columns.Add("ColFour");
			source.Columns.Add("ColFive");
			for (var rowIndex = 0; rowIndex < 5; rowIndex++)
			{
				for (var colIndex = 0; colIndex < source.Columns.Count; colIndex++)
				{
					sourceData[colIndex] = rowIndex * colIndex;
				}
				source.Rows.Add(sourceData);
			}
			DataTable target = new DataTable();
			target = source.Clone();
			Console.WriteLine("Before split");
			Console.Write("Source -> ");
			foreach (DataColumn col in source.Columns) { 
				Console.Write(col.ColumnName + ", ");
			}
			Console.WriteLine();
			Console.Write("Target -> ");
			foreach (DataColumn col in target.Columns)
			{
				Console.Write(col.ColumnName + ", ");
			}
			Console.WriteLine();
			target.Columns.RemoveAt(0);
			target.Columns.RemoveAt(0);
			target.Columns.RemoveAt(0);
			source.Columns.RemoveAt(3);
			source.Columns.RemoveAt(3);
			Console.WriteLine();
			Console.WriteLine("After split");
			Console.Write("Source -> ");
			foreach (DataColumn col in source.Columns)
			{
				Console.Write(col.ColumnName + ", ");
			}
			Console.WriteLine();
			Console.Write("Target -> ");
			foreach (DataColumn col in target.Columns)
			{
				Console.Write(col.ColumnName + ", ");
			}
			Console.WriteLine();
			if (Debugger.IsAttached) {
				Console.WriteLine();
				Console.WriteLine("ANY KEY TO EXIT");
				Console.ReadKey(true);
			}
		}
