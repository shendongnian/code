        void applyFilter()
		{
			foreach (DataGridViewRow row in grid1.Rows)
			{
				string columnA = row.Cells["ColumnA"].Value as string;
				string columnB = row.Cells["ColumnB"].Value as string;
				row.Visible = (columnA == "valueA" && columnB == "valueB");
			}
		}
