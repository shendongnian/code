    while(myReader.Read())
    {
    
    if (myReader.Read())
                    {
                         allcitiesnames.Add(myReader.GetString(myReader.GetOrdinal("CityName")));
    
                    }
                    else
                    {
                        mySqlConnection.Close();
                        InsertNewCity(countrycode);
    
                    }
    }
