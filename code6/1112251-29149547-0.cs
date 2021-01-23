	DataTable DistinctTable = SourceTable.DefaultView.ToTable();
	if (DistinctTable.Rows.Count > 0)
	{
		if (!DistinctTable.Columns.Contains("ColumnA"))
		{
			DistinctTable.Columns.Add("ColumnA", typeof(String));
		}
		if (!DistinctTable.Columns.Contains("ColumnB"))
		{
			DistinctTable.Columns.Add("ColumnA", typeof(String));
		}
		if (!DistinctTable.Columns.Contains("ColumnC"))
		{
			DistinctTable.Columns.Add("ColumnC", typeof(String));
			//you can also move the new columns by using SetOrdinal, like so:
			DistinctTable.Columns[DistinctTable.Columns.Count - 1].SetOrdinal(DistinctTable.Columns.Count - 2);
			//but careful, this gets messy very quickly
		}
	}
	//return DistinctTable //(?)
