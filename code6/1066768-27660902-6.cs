    User usr = null;
    int curUserID = -1;
    while (myReader.Read())
    {
        int id = Convert.ToInt32(myReader["UserId"]);
        if(curUserID != id)
        {
            // Enter this block only if the user changes from the previous one
            // They are ordered so you are sure to get them in line
            usr = new User()
            {
                 Id = id, 
                 Name = reader["Name"].ToString(), 
                 Coordinates = new List<Coordinate>()
            };
            curUserID = id;
            listOfUsers.Add(usr);
        }
        // Add all the coordinates that belong to the same user
        Coordinate cc = new Coordinate()
        {
            cc.coordID = Convert.ToInt32(reader["CheckPointID"]);
            cc.TimeStamp = Convert.ToDateTime(reader["TimeStamp"]);
            cc.Location = reader["Location"].ToString();
        };
        usr.Coordinates.Add(cc);
    }
