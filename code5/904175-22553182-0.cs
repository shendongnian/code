     protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
     {
        try
        {
            string id = GridView1.DataKeys[e.RowIndex].Values["with_puja"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "delete   from shoppingcart where with_puja='" + id + "'";
            cmd.Connection = con;
            con.Open();            
            cmd.ExecuteNonQuery();
        }
        catch (Exception ex)
        {            
            Response.Write("<script>alert('An Error occurred.</script>");
        }
        finally
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();                
            }
            Bindgrid();
        }
    }
