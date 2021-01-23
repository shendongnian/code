        if (dataReader.HasRows)
        {
            while (dataReader.Read())
            {
                //Converts the values in the tables to strings
                aretheyManager = Convert.ToString(dataReader["isManager"]);
                listedanalystEmail = Convert.ToString(dataReader["analystEmail"]);
                listedmanagerEmail = Convert.ToString(dataReader["managerEmail"]);
                // For every record read, send the email
                sendEmailNotification(aretheyManager, 
                                      listedanalistEmail, 
                                      listedmanagerEmail)                        
            }
        }
