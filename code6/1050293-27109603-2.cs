    protected void grdCSRPageData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                int rowIndex = ((GridViewRow)((ImageButton)e.CommandSource).NamingContainer).RowIndex;
                grdCSRPageData.Rows.RemoveAt(rowIndex);
                //delete from database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                   int Id = Convert.ToInt32(e.CommandArgument);
                   string sql = "DELETE FROM YourTable WHERE ID = @ID";
                   SqlCommand cmd = new SqlCommand(sql,connection);
                   cmd.Parameters.AddWithValue("@ID",Id);
                   cmd.ExecuteNonQuery();
               }
            }
        }
