    private void BindProgramatically() {
    
    	//obtain the data from your OleDB connection
    	DataSet ds = GetData(constr);
    	if(ds == null) {
    		return;
    	}
    	DataTable dt = ds.Tables[0];
    	
    	//build the grid structure, add a new grid column for each datatable column
    	for(int i = 0; i < dt.Columns.Count; i++) {
    		DataGridViewColumn newColumn = new DataGridViewColumn();
    		newColumn.Name = dt.Columns[i].ColumnName;
    		dataGridView1.Columns.Add(newColumn);
    	}	
    	
    	for (int i = 0; i < dt.Rows.Count; i++) {
    		//call ToArray to pass a copy of the data from the datatable
    		//(make sure you have 'using System.Linq;' at the top of your file
    		dataGridView1.Rows.Add(dt.Rows[i].ItemArray.ToArray());
    	}
    }
