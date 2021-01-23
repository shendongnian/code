    var groups = userLoginTrials.GroupBy(u => u.UserId);
    foreach(var group in groups)
    {
        // group.Key is the UserId
        // group will contain an IEnumerable<UserLoginTrial> with that UserId
        foreach(var userLoginTrial in group)
        {
        // Add your logic here
        }
    }
