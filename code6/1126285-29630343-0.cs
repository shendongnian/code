    var memberList = new List<User>();
    
    AllUsers.Foreach(user=>
    {
        user.Teams.Foreach(id=>
                          {
                              if(currentUserTeams.Contains(id)
                              {
                                  memberList.Add(user);
                                  Break; //Because you don't need to loop through the rest of the sequence 
                              }
                          })
    })
