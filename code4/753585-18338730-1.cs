	private void moviesGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
	{
		//make sure click not on header and column is type of ButtonColumn
		if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].GetType() ==  _
							   typeof(DataGridViewButtonColumn))
		{
			 MovieDetailsForm form = new MovieDetailsForm(MovieDetailsForm.MovieViewMode.Read);
			 form.ShowDialog();
		}
	}
