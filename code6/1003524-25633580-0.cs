    public Worksheet exportToExcel(System.Data.DataTable dataTable)
    {
    	//Wrap in using statements to make sure controls are disposed
    	using (Form frm = new Form())
    	{
    		using(DataGridView dgv = new DataGridView())
    		{			
    			dgv.DataSource = dataTable;			
    			frm.Controls.Add(dgv);     
    			return exportToExcel(dgv);
    		}
    	}	
    }
