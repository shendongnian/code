	private void dataGridView1_RowErrorTextNeeded( object sender, DataGridViewRowErrorTextNeededEventArgs e )
	{
		DataGridView dataGridView = sender as DataGridView;
		if( dataGridView != null )
		{
			DataRowView view = dataGridView.Rows[e.RowIndex].DataBoundItem as DataRowView;
			if( view != null )
			{
				if( view.Row[invColorColumn] == DBNull.Value )
					e.ErrorText = "Color code is missing from part database.";
				else if( view.Row[invThickColumn] == DBNull.Value )
					e.ErrorText = "Thickness is missing from part database.";
				else if( view.Row[invWidthColumn] == DBNull.Value )
					e.ErrorText = "Width is missing from part database.";
				else if( view.Row[invHeightColumn] == DBNull.Value )
					e.ErrorText = "Height is missing from part database.";
				else 
					e.ErrorText = String.Empty;
			}
		}
	}
