	// create a hashset for fast confirmation of app names
	var realAppNames = new HashSet<string>(appList.Select(a => a.AppName));
	
	var roster = MURLEngine.GetUserFriendDetails(token, userId);
	
	// get the ids of all friends
	var friendIds = roster.RosterEntries
                          .Where (e => e[0] == 'm' && e[1] >= '0' && e[1] <= '9');
	
	var apps = 
        friendIds 
		// get the rosters for all friends
		.SelectMany (friendId => MURLEngine.GetUserFriendDetails(token, friendId)).RosterEntries)
		// include the original user's roster so we get their apps too
		.Concat(roster.RosterEntries) 
		// filter down to apps only
		.Where (name => name[0] != 'm' && realAppNames.Contains(name)) 
		// remove duplicates
		.Distinct()
		// we're done!
		.ToList();
