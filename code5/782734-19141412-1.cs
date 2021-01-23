    using(SqlConnection sc = new SqlConnection("yourConnectionString"))
    {
    
       cmd = new SqlCommand("Insert into Table (Code, v1, v2, v3) values(@code, @v1, @v2, @v3)", sc);
       cmd.Parameters.Add("@code");
       cmd.Parameters.Add("@v1");
       cmd.Parameters.Add("@v2");
       cmd.Parameters.Add("@v3");
       sc.Open();
       foreach (DataRow row in objDataset1.Tables[0].Rows)
       {
            string strValue = row["code"].ToString();       
            //Assing the values for above parameters here.
            cmd.Parameters["@code"].Value = strValue;
            cmd.Parameters["@v1"].Value = valueForV1;
            ...
            //Execute the command
            cmd.ExecuteNonQuery(); 
       }
    }
