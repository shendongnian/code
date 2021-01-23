    using(SqlConnection sc = new SqlConnection("yourConnectionString"))
    {
    
       cmd = new SqlCommand("Insert into [tbl] (Code, v1, v2, v3) Values(@code, @v1, @v2, @v3)", sc);
       cmd.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar));
       cmd.Parameters.Add(new SqlParameter("@v1", SqlDbType.Bit));
       cmd.Parameters.Add(new SqlParameter("@v2", SqlDbType.Bit));
       cmd.Parameters.Add(new SqlParameter("@v3", SqlDbType.Bit));
       sc.Open();
       foreach (DataRow row in objDataset1.Tables[0].Rows)
       {
      
            //Assign the values for above parameters here.
            cmd.Parameters["@code"].Value = row["code"].ToString();
            cmd.Parameters["@v1"].Value = valueForV1;
            cmd.Parameters["@v2"].Value = valueForV2;
            cmd.Parameters["@v3"].Value = valueForV3;
            //Execute the command
            cmd.ExecuteNonQuery(); 
       }
    }
