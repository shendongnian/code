    private void btnBatchInsert_Click(ArrayList data)
    {
         sqlcon.Open();
         SqlCommand command = new SqlCommand();
         command.Connection = sqlcon;
         // Add to the parameters collection a specific parameter with appropriate type and size 
         command.Parameters.Add(new SqlParameter("@sno",  SqlDbType.NVarChar, 32));
         ....
         for (int j = 0; j < data.Count; j++)
         {
             command.Parameters["@sno"].Value = arr[0].ToString();
             ....
             command.ExecuteNonQuery();
         }
    }
