                    Person p1 = null; 
                    
                    List<Person> personList = new List<Person>(); //To fill with data retrieve from database 
    //Method to fill Class with data
                   public void getAllPersonData()
                    {
                        try
                        {
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            string query = "SELECT * FROM Persons";
                            SqlCommand cmd = new SqlCommand(query, con);
                            
                            SqlDataReader rdr = cmd.ExecuteReader();
                            
                            while (rdr.Read())
                            {
                                p1 = new Person(); //Create Instances
                                p1.age = rdr.GetInt32(0);
                                p1.name = rdr.GetString(1);
                                personList.Add(p1);                                
                            }
                        }
                        catch (SqlException x)
                        {
                            MessageBox.Show(x.Message);
                        }
                    }
                    
        
        
