                SqlConnection myConnection = new SqlConnection("Data Source=.;Initial Catalog=db_myDB;Integrated Security=true");
                SqlDataReader myReader=null;
    
                int i = 0;
    
                myConnection.Open();
                
              
                
                 myReader = new SqlCommand("select  countryname from dbo.countries", myConnection).ExecuteReader();
    
                    while (myReader.Read())
                    {
    
                        ListBoxItem li = new ListBoxItem();
                        li.Content = myReader.GetString(0);
                        listBox1.Items.Add(li);
    
                        if(i<3)
                        li.Background = Brushes.Blue;
    
                        i++;
                    }
    
                  myConnection.Close();
