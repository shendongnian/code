     public void Main()
        	{
                DataTable dt            = new DataTable();
                OleDbDataAdapter da     = new OleDbDataAdapter();
                //Read the original table
                da.Fill(dt, Dts.Variables["Tbl"].Value);
                //Push to a replica
                Dts.Variables["TblClone"].Value = dt;
        
                Dts.TaskResult = (int)ScriptResults.Success;
        	}
