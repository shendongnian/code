        using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand(query, conn);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            //This is the initial table
            DataTable dtDetails = new DataTable();
            da.Fill(dtDetails);
            
            //This is the table for whom i need to change the datatype of columns
            DataTable dtCloned = dtDetails.Clone();
            dtCloned.Columns["myColumn1"].DataType = System.Type.GetType("System.String");
            dtCloned.Columns["myColumn2"].DataType = System.Type.GetType("System.String");
            
            //Copy all data from first table to this new table
            foreach (DataRow dr in dtDetails.Rows)
            {
                dtCloned.Rows.Add(dr.ItemArray);
            }
            GridProjectDetails.DataSource = dtCloned;
            GridProjectDetails.DataBind();
            
           //Then you can export this Grid
        }
