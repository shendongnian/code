    protected void txtUserName_TextChanged(object sender, EventArgs e)   
            {     
                try   
                {    
                    string userName = txtUserName.Text;
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();
     
    <pre>
                command = new SqlCommand();
                command.CommandText = &quot;Get_UserName&quot;;
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue(&quot;@userName&quot;, userName);
                command.Connection = connection;
     
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    lblUserNameError.Text = &quot;Alredy Exist&quot;;
                    lblUserNameError.Visible = true;
                    btnSave.OnClientClick = &quot;return false;&quot;;
                }
                else
                {
                    lblUserNameError.Visible = false;
                    btnSave.OnClientClick = &quot;return true;&quot;;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally //Close db Connection if it is open....
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
                connection.Close();
                command.Dispose();
            }
        }
