    Use `Parametarized` and `Using{}` statement to auto dispose and close connection
    using( SqlConnection objConnection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\19-02\ABCC\App_Data\abcc.mdf;Integrated Security=True;User Instance=True"))
                {
                        objConnection.Open();
    
                        try
                        {
                        
                            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM recipe WHERE  nor LIKE "'%" @query "%'"" , con))
                           DataTable dt= new DataTable();
                            da.SelectCommand.Parameters.AddWithValue("@query",query.Text); 
                           da.Fill(dt);
    
                           
                        }
                        catch(System.Data.SqlClient.SqlException ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
    
                       
    
                    }
