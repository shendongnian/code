    //Get the current team memberships for a user
    var user = restApi.GetByReference("/user/12345", "TeamMemberships");
    Request teamMemberRequest = new Request(user["TeamMemberships"]);
    List<DynamicJsonObject> teams = new List<DynamicJsonObject>(restApi.Query(teamMemberRequest).Results.Cast<DynamicJsonObject>());
    
    //Add the new team (project)        
    DynamicJsonObject newTeam = new DynamicJsonObject();
    newTeam["_ref"] = "/project/23456";
    teams.Add(newTeam);
    //Update the user
    DynamicJsonObject toUpdate = new DynamicJsonObject();
    toUpdate["TeamMemberships"] = teams;
    restApi.Update(user["_ref"], toUpdate);
    
