    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    	//Check if we're formatting the color column
        if (this.dataGridView1.Columns[e.ColumnIndex].Name == "Color")
        {
    		//Make sure there's a value set
            if (e.Value != null)
            {
                string colorCode = (string)e.Value;
                ColorConverter cc = new ColorConverter();
                e.CellStyle.BackColor = (Color)cc.ConvertFromString("#" + colorCode);
                //If you don't want the code to show
                e.Value = "";
                e.FormattingApplied = true;
            }
        }
    }
