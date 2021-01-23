	private void FindLinkingTables(
		List<TableColumns> sourceList, TableSearchNode parentNode,
		string targetTable, int maxSearchDepth)
	{
		if (parentNode.Level < maxSearchDepth)
		{
			var sames = sourceList.Where(w => w.Table == parentNode.Table);
			
			var query =
				from x in sames
				join y in sames
					on x.Column.Substring(1) equals y.Column.Substring(1)
				where !parentNode.Ancenstory.Contains(y.Table)
				select new TableSearchNode
				{
					Table = x.Table,
					Column = x.Column,
					Level = parentNode.Level + 1
				};
				
			foreach (TableSearchNode z in query)
			{
				parentNode.AddChildNode(z.Column, z);
				if (z.Table != targetTable)
				{
					FindLinkingTables(sourceList, z, targetTable, maxSearchDepth);
				}
				else
				{
					z.NotifySeachResult(true);
				}
			}
		}
	}
