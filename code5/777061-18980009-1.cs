	protected void btndelete_Click(object sender, EventArgs e)
	{
		// Get the Table from the session.
	    DataTable dt = (DataTable)Session["CurrentTable"];
	    // Only actually proceed, if we have a value.
	    if(dt != null)
	    {
	    	// Loop through each item.
	        for (int i = 0; i < listview1.Items.Count - 1; i++)
		    {
		    	// Find the checkbox to determine if it's checked.
		        ListViewDataItem items = listview1.Items[i];
		        CheckBox chkBox = (CheckBox)items.FindControl("chkdel");
		        if (chkBox.Checked == true)
		        {
		        	// Remove the row at the current index.
		        	dt.rows.RemoveAt(i);
		        }
		    }
		    // Update the session and rebind the data.
		    Session["CurrentTable"] = dt;
		    listview1.DataSource = dt;
		    listview1.DataBind();
		    BindDataToGridviewDropdownlist(); 
	    }
	}
