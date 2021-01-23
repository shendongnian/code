      //create a class to hold the value
    class SomeDTO
    {
       public string aretheyManager;
       public string listedanalystEmail;
       public string listedmanagerEmail;
    }
      //in your main
     //Reads values in specified columns in the database
                List<SomeDTO> collection = new List<SomeDTO>();
                using (SqlDataReader dataReader = selectValues.ExecuteReader())
                {
                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                           SomeDTO obj = new SomeDTO();
                            //Converts the values in the tables to strings
                            obj.aretheyManager = Convert.ToString(dataReader["isManager"]);
                            obj.listedanalystEmail = Convert.ToString(dataReader["analystEmail"]);
                            obj.listedmanagerEmail = Convert.ToString(dataReader["managerEmail"]);
    
                           collection.Add(obj);
                         
                        }
                    }
                    dataReader.Close();
                    dataReader.Dispose();
                }
    //send email notification method
    private void sendEmailNotification(List<SomeDTO> obj)
    {
         //loop and send email
    }
