            OleDbConnection conn = new OleDbConnection(constr);
            conn.Open();
    
            string cmdstr = "SELECT Picture FROM Gegevens WHERE ID =" + id;
            OleDbCommand cmd = new OleDbCommand(cmdstr, conn);           
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
    
            DataSet ds = new DataSet();
            da.Fill(ds, "picture");
    
            if (ds != null && Data.Tables[0].Rows.Count > 0)
            {
            DataRow dr = ds.Tables["Pictures"].Rows[0]; //Here i get the error!
    
            byte[] result = (byte[])dr["Picture"];
            int ArraySize = result.GetUpperBound(0);
    
            MemoryStream ms = new MemoryStream(result, 0, ArraySize);
            Picturebox1.Image = Image.FromStream(ms);
            }
            conn.Close();
