    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
   
    
        if (e.CommandName.Equals("DeleteRow"))
        {
            GridViewRow oItem = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
            int RowIndex = oItem.RowIndex;
            
            girdivewBind(); // Bind your gridview again. 
        }
    
    }
    public void deleteRecord(string ID)
    {
      using (SqlConnection con = new SqlConnection(cn.ConnectionString))
       {
         using (SqlCommand cmd = new SqlCommand())
         {
            cmd.CommandText = "delete from Mytable where ID=@id";
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", ID);
            con.Open();
            var temp = cmd.ExecuteNonQuery();
            con.Close();
           }
       }
     }
