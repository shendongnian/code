foreach(var user in db.Users)
As an alternative, one might do something like this, which worked for me:
    var listOfUsers = db.Users.Select(r => new UserModel
        					 {
        						 userModel.FirstName = r.FirstName;
                                 userModel.LastName = r.LastName;
        						 
        					 });
    
    return listOfUsers.ToList();
However, I ended up using Lucas Roselli's solution.
**Update: Simplified by returning an anonymous object:**
    var listOfUsers = db.Users.Select(r => new 
         					 {
        						 FirstName = r.FirstName;
                                 LastName = r.LastName;
        					 });
    
    return listOfUsers.ToList();
