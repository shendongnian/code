                    if (cells[0].Value!= null)
                    if ((cells[0].Value as string ).Contains("==="))/*end of section*/
                    {
                        if(c == Color.Gray)
                        {
                          c = Color.Transparent;                              
                        }
                        else
                        {                 
                           c = Color.Gray;
                        }
                    }
