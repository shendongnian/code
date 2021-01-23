    public void delete(int id)
    { 
       try 
       {
          con.Open();
          OleDbCommand comm = new OleDbCommand("delete from 'TableName' where id=@id", con);
          comm.Parameters.AddWithValue("@id", id);
          comm.ExecuteNonQuery();
       }
       catch(OleDbException ex)
       {
           MessageBox.Show("DataConnection not found!", ex);
       }
       finally
       {
           con.Close();
       }
