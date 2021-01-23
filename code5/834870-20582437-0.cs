    if (dr.Read())
                {
                  for (int i = 0; i <columnsCount; i++)
                    {
                           str2 +=  string.Join(";",sdr.GetString(i)); 
                    }
                
        
                } 
