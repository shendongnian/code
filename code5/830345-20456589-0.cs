    if (dbReader.HasRows)
            {
               bool found  = false;  
                while (dbReader.Read())
                {
    
                    if (dbReader["PatientID"] != DBNull.Value)
                    {
    
                        int anInteger;
                        anInteger = Convert.ToInt32(textBox7.Text);
                        anInteger = int.Parse(textBox7.Text);
    
                        if (anInteger == 101)
                        {
                            found = true ;  Break; 
    
                        }
    
                    }
    
    
                }
            }
