      private void insert()
            {
                connection.Open();
    
               
                for(int i=0; i< gvAdditionalDetails.Rows.Count ; i++)
                {
                    DropDownList DropDownListType =
                             (DropDownList)gvAdditionalDetails.Rows[i].Cells[1].FindControl("DropDownListType");
    
    
    
                    TextBox TextBoxDescription =
                    (TextBox)gvAdditionalDetails.Rows[i].Cells[i].FindControl("txtDescription");
                       
                    string sql = "insert into [CONTACT_DETAILS] (type,description,contactID) VAlUES (@row1,@row2,@contactID )";
    
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
    
                    cmd.Parameters.AddWithValue("@row1", DropDownListType.SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@row2", TextBoxDescription.Text.Trim());
                    cmd.Parameters.AddWithValue("@contactID", 39);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
