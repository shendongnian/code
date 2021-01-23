    private DataSet GetData(string constr) {
    	//'using' constructs are always a good idea when dealing with database operations
    	//your connection will automatically close
    	using(OleDbConnection con = new OleDbConnection(constr)){
    		using(OleDbCommand cmd = new OleDbCommand()){		
    			cmd.Connection = con;
    			cmd.CommandText = "select * from tb1";
    			cmd.CommandType = CommandType.Text;
    			OleDbDataAdapter da = new OleDbDataAdapter();
    			da.SelectCommand = cmd;
    			DataSet ds = new DataSet();
    			da.Fill(ds);
    			return ds;
    		}
    	}
    }
