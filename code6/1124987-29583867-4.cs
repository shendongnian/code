         public void SelectDB(int id) 
         {              
                string Query = "Select * from Students where ID = " + id;
                try  
               {
                        DataTable dt= DBSetup(Query);
                        for(int i=0; i<dt.Rows.Count; i++)
                        {
                          setid(dt.Rows[i]["ID"]);
                          setPassword(dt.Rows[i]["password"]);
                          setEMail(dt.Rows[i]["email"]);
                          setGpa(Double.Parse(dt.Rows[i]["Gpa"]));
                        }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                }
                                    
            }
