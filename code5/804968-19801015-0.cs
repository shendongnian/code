	private void grids_CellEditEnding(object sender, Microsoft.Windows.Controls.DataGridCellEditEndingEventArgs e)
	{
		try
		{
			Microsoft.Windows.Controls.DataGrid grid = (Microsoft.Windows.Controls.DataGrid)sender;
			gridNumber = Convert.ToInt16(grid.Name.Substring(grid.Name.Length - 1, 1)) - 1;
			if (!isManualEditCommit)
			{
				isManualEditCommit = true;
				grid.CommitEdit(Microsoft.Windows.Controls.DataGridEditingUnit.Row, true);
				using (SqlConnection con = new SqlConnection(GUI.dictSettings["connectionString"]))
				{
					con.Open();
					SqlCommandBuilder com = new SqlCommandBuilder(adapters[gridNumber]);
					adapters[gridNumber].UpdateCommand = com.GetUpdateCommand();
					adapters[gridNumber].Update(tables[gridNumber]);
					tables[gridNumber].AcceptChanges();
					con.Close();
				}
				isManualEditCommit = false;
			}
		}
		catch (DBConcurrencyException ex)
		{
			isManualEditCommit = false;
			reloadData();
			
		} catch(Exception ex){
			isManualEditCommit = false;
			reloadData();
		}
	}
