    using (SqlConnection c = new SqlConnection("your connection string"))                                    
    {                                                                                                        
        c.Open();                                                                                            
        using (SqlCommand cmd = new SqlCommand("INSERT INTO table (field1, field2) VALUES (@field1, @field2))
        {                                                                                                    
            foreach (ListItem item in listbox2.Items)                                                        
            {                                                                                                
                cmd.Parameters.Clear();                                                                      
                cmd.Parameters.AddWithValue("@field1", item.Value);                                          
                cmd.Parameters.AddWithValue("@field2", item.Text);                                           
                                                                                                             
                cmd.ExecuteNonQuery();                                                                       
            }                                                                                                
        }                                                                                                    
    } 
