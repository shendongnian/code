                try
                {
                    using (SqlConnection conn = new SqlConnection(_pageDataBase.connectionString()))
                    {
                        conn.Open();
                        
                        DataTable dt = new DataTable();
    
                        SqlDataAdapter Usergroups= new SqlDataAdapter("select *from Usergroups", conn);
                        Usergroups.Fill(dt);
    
                        SqlDataAdapter Groups= new SqlDataAdapter("select *from Groups", conn);
                        Groups.Fill(dt);
    
                        datagridName.ItemsSource = dt.DefaultView;      
    
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
