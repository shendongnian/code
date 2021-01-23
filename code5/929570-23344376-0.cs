    List<Row> data = new List<Row>
    {
    	new Row { IsFavorite = true },
    	new Row { IsFavorite = false },
    };
    
    dataGridView1.Columns.Add(new DataGridViewImageColumn(false));
    dataGridView1.Columns[0].DataPropertyName = "IsFavorite";
    dataGridView1.Columns[0].DefaultCellStyle.NullValue = null;
    dataGridView1.DataSource = data;
    private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
    	if (e.ColumnIndex == 0)
    	{
    		if (e.Value != null && e.Value is bool)
    		{
    			if ((bool)e.Value == true)
    			{
    				e.Value = imageList1.Images[0];
    			}
    			else
    			{
    				e.Value = null;
    			}
    		}
    	}
    }
    public class Row
    {
    	public bool IsFavorite { get; set; }
    }
