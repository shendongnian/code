    private void insert()
            {
                connection.Open();
    
                for(int i=0; i< gvAdditionalDetails.Rows.Count ; i++)
                {
                    string sql = "insert into [CONTACT_DETAILS] (type,description,contactID) VAlUES (@row1,@row2,@contactID )";
    
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    cmd.CommandType = CommandType.Text;
    
                    cmd.Parameters.AddWithValue("@row1", ((DropdownList)gvAdditionalDetails.Rows[i].FindControl("DropDownListType")).SelectedItem.Text.Trim());
                    cmd.Parameters.AddWithValue("@row2", ((TextBox)gvAdditionalDetails.Rows[i].FindControl("txtDescription")).Text.Trim());
                    cmd.Parameters.AddWithValue("@contactID", 39);
                    cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
