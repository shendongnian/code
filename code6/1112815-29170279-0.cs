    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    	//Check if we're formatting the color column
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Color")
        {
    		//Make sure there's a value set
            if (e.Value != null)
            {
                string colorCode = (string)e.Value;
                e.CellStyle.BackColor = (Color)ColorConverter.ConvertFromString("#" + colorCode)
            }
        }
    }
