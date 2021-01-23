	DataGridViewRow row = new DataGridViewRow();
	row.CreateCells(dgvArticles);
	DataGridViewCell CellByName(string columnName)
	{
	    var column = dgvArticles.Columns[columnName];
	    if (column == null)
	        throw new InvalidOperationException("Unknown column name: " + columnName);
	    return row.Cells[column.Index];
	}
	CellByName("code").Value = product.Id;
	CellByName("description").Value = product.Description;
	.
	.
	.
	dgvArticles.Rows.Add(row);
