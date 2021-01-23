    private void button1_Click(object sender, EventArgs e)
    {
    	var dt = new DataTable();
    	dt.Columns.Add("test");
    
    	var rnd = new Random();
    	for (int i = 0; i < 10000; i++)
    	{
    		var dr = dt.NewRow();
    		dr[0] = rnd.Next().ToString();
    		dt.Rows.Add(dr);
    	}
    	dataGridView1.DataSource = dt;
    }
    
    int i = 0;
    int lastTopRow = 0;
    var isRecursive = false;
    private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
    {
    	if (isRecursive) return;
    	//Honor each 20th scroll for "*attempted gradual*" scrolling
    	if (i % 20 == 0)
    	{
    		lastTopRow++;
    	}
    
    	isRecursive = true;
    	dataGridView1.FirstDisplayedScrollingRowIndex = lastTopRow;
    	isRecursive = false;
    	//Boundary check
    	if (i > int.MaxValue) i = 0;
    	i++;
    }
