    private void GridView1_Click(object sender, EventArgs e)
    {
    	System.Data.DataRow row = GridView2.GetDataRow(GridView2.FocusedRowHandle);
    	if(row[0].ToString() == "")
        {
              //YOUR LOGIC
        }
    	
    }
