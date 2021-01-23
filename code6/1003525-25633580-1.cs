    public Worksheet exportToExcel(System.Data.DataTable dataTable)
    {
    	//Wrap in using statements to make sure controls are disposed
    	using (Form frm = new Form())
    	{
    		using(DataGridView dgv = new DataGridView())
    		{	
                //Add dgv to form before setting datasource	    						
    			frm.Controls.Add(dgv);  
                dgv.DataSource = dataTable;   
    			return exportToExcel(dgv);
    		}
    	}	
    }
