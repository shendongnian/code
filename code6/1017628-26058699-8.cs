    var userIdGroups = new Dictionary<int, HashSet<Group>>();
    var groupIdUsers = new Dictionary<int, HashSet<User>>();
    for(int i = 0; i < result.Length; i += 4)
    {
        int id;
        if(int.TryParse(result[i], out id))
        {
            string name = result.ElementAtOrDefault(i + 1);
            if(name == null)
                continue; // end, invalid data
            
            User user = new User{ UserId = id, Name = name };
            string groupID = result.ElementAtOrDefault(i + 2);
            if(!int.TryParse(groupID, out id))
                continue; // end, invalid data
            name = result.ElementAtOrDefault(i + 3);
            if(name == null)
                continue; // end, invalid data
            Group group = new Group{ GroupId = id, Name = name };
            HashSet<Group> userGroups;
            HashSet<User> groupUsers;
            if (userIdGroups.TryGetValue(user.UserId, out userGroups))
                userGroups.Add(group);
            else
                userIdGroups.Add(user.UserId, new HashSet<Group>{ group });
            if (groupIdUsers.TryGetValue(group.GroupId, out groupUsers))
                groupUsers.Add(user);
            else
                groupIdUsers.Add(group.GroupId, new HashSet<User> { user });
        }
    }
