    User usr = null;
    int curUserID = -1;
    while (myReader.Read())
    {
        int id = Convert.ToInt32(myReader["UserId"]);
        if(curUserID != id)
        {
            // Enter this block only if the user changes from the previous
            usr = new User()
            {
                 Id = id, 
                 Name = reader["Name"].ToString(), 
                 coordinates = new List<Coordinate>()
            }
            curUserID = id;
            listOfUsers.Add(usr);
        }
        // Add all the coordinates that belong to the same user
        Coordinate cc = new Coordinate()
        {
            cc.coordID = Convert.ToInt32(reader["CheckPointID"]);
            cc.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
            cc.Coordinates = reader["Coordinates"].ToString();
        }
        usr.coordinates.Add(cc);
    }
