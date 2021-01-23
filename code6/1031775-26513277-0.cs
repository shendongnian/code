    ((SqlSyncProvider)syncOrchestrator.LocalProvider).ChangesSelected += SelectOnlyNewRows;
    void SelectOnlyNewRows(object sender, DbChangesSelectedEventArgs e)
    {
	  foreach (DataTable table in e.Context.DataSet.Tables)
	  {
	    for (int i = table.Rows.Count - 1; i >= 0; i--)
		{
	      DataRow row = table.Rows[i];
		  // We are only interested in the new rows.
		  if (row.RowState != DataRowState.Added)
			table.Rows.Remove(row); // Delete the row so it doesn't get sent.
		}
	  }
    }
