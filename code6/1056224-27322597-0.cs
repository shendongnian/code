    public IEnumerable<Post> postsForFlow(int userID, string userName)
    {
        var userToFollowID = db.Follow.Where(a => 
                      a.loggedInUser.Id == userID).Select(b => b.userToFollow.Id).ToList();
        userToFollowID.ForEach(user =>
              {
                    Follow(user); // Use whatever logic you need for following.  "user" is the int you want
              });
        return null;
    }
