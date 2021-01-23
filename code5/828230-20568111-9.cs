    // In the DataField class, have this code.
    // This method will query the database for all usernames and user ids and
    // return a Dictionary<int, string> where the key is the Id and the value is the 
    // username. Make this a global variable within the DataField class.
    Dictionary<int, string> usernameDict = GetDataFromDB("select id, username from Users");
    // Then in the GetValue(int userId) method, do this:
    public string GetValue(int userId)
    {
        // Add some error handling and whatnot. 
        // And a better name for this method is GetUsername(int userId)
        return this.usernameDict[userId];
    }
