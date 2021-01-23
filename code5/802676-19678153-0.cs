    public bool IsCorrectUser(User u) { return u.UserId == 5; }
    
    // An exception should be raised when there are no matches
    var firstHit = AllUser.First(IsCorrectUser);
    
    // When it is okey not to have a match
    User firstHit;
    if ((firstHit = AllUser.FirstOrDefault(IsCorrectUser) != null)
    {
      // Use the firstHit variable
    }
