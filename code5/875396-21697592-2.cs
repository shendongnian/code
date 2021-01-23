    		List<List<Tuple<string, string>>> tuples = new List<List<Tuple<string, string>>>();
			//if you have more than one row, some how you xml should be formatted hierarchically,
			//so you need to create an outer loop here and iterate through parent nodes (rows):
			List<Tuple<string, string>> tuple = new List<Tuple<string,string>>();
			foreach(var node in xdoc.Root.Elements())
			{
				string nodeName = node.Name.LocalName;
				if (!dt.Columns.Contains(nodeName))
				{
					dt.Columns.Add(nodeName);
				}
				tuple.Add(Tuple.Create(nodeName, node.Value));
			}
			tuples.Add(tuple);
			foreach (var row in tuples)
			{
				DataRow dr = dt.NewRow();
				foreach (var r in row)
				{
					dr[r.Item1] = r.Item2;
				}
				dt.Rows.Add(dr);
			}
