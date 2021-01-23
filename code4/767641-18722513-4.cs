              List<string> aretheyManager = new List<string>(); 
              List<string> listedanalystEmail =new List<string>();  
             List<string> listedmanagerEmail = new List<string>();  
            while (dataReader.Read())
                    {
                    //Converts the values in the tables to strings
                   aretheyManager.Add(Convert.ToString(dataReader["isManager"]));
                   listedanalystEmail.Add( Convert.ToString(dataReader["analystEmail"]));
                   listedmanagerEmail.Add(Convert.ToString(dataReader["managerEmail"]));
                    }
