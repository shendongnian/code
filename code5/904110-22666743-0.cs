     protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
  {
	 int x = Convert.ToInt32(DropDownList1.SelectedItem.ToString()); // Number of rows
        DataTable dt = new DataTable();
	 for (int i = 0; i < x; i++)
       	 {
            DataRow row1 = dt.NewRow();
	     dt.Rows.Add(row1);
        }
	 for (int i = 0; i < x; i++)
        {
            DataRow row1 = dt.NewRow(); //Adding rows
            
            dt.Rows.Add(row1);
        }
	 
        //Bind the datatable with the GridView.
	GridView1.DataSource = dt;
        GridView1.DataBind();
