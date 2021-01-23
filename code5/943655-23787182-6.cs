    private void DataGridView_CellParsing(object sender, DataGridViewCellParsingEventArgs e)
        {
        //Get the id, (assuming that the id is in the first column)
        id =int.Parse(DataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
        
        //If you need more comparison, you can get the name of the column and the new value of the cell too         
         nameOfcolumn = DataGridView.Columns[e.ColumnIndex].Name;
         newValue = e.Value.ToString();
        }
