        if (dataReader.HasRows)
        {
            while (dataReader.Read())
            {
                //Converts the values in the tables to strings
                aretheyManager = Convert.ToString(dataReader["isManager"]);
                listedanalystEmail = Convert.ToString(dataReader["analystEmail"]);
                listedmanagerEmail = Convert.ToString(dataReader["managerEmail"]);
                sendEmailNotification(aretheyManager, 
                                      listedanalistEmail, 
                                      listedmanagerEmail)                        
            }
        }
