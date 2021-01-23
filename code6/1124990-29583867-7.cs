         public void SelectDB(int id) 
         {              
                string Query = "Select * from Students where ID = " + id;
                try  
               {
                        DataTable dt= DBSetup(Query);
                        for(int i=0; i<dt.Rows.Count; i++)
                        {
                          setid(Convert.ToInt32(dt.Rows[i]["ID"]));
                          setPassword(dt.Rows[i]["password"].ToString());
                          setEMail(dt.Rows[i]["email"].ToString());
                          setGpa(Double.Parse(dt.Rows[i]["Gpa"]));
                          // ID,password,email,gpa these are column names
                          // you should replace with your column names
                        }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
                                    
            }
