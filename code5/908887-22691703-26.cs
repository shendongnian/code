    public TestProperties : SetupPerTest
    {
       [Test]
       public void EnsureCorrectReferenceIsLoaded()
       {
          int friendID = 0;
          this.RunTest(session =>
          {
             var user = CreateUserWithFriend();
             session.Save(user);
             friendID = user.Friends.Single().FriendID;
          } () =>
          {
             var user = GetUser();
             Assert.AreEqual(friendID, user.Friends.Single().FriendID);
          });
       }
       [Test]
       public void EnsureOnlyCorrectFriendsAreLoaded()
       {
          int userID = 0;
          this.RunTest(session =>
          {
             var user = CreateUserWithFriends(2);
             var user2 = CreateUserWithFriends(5);
             session.Save(user);
             session.Save(user2);
             userID = user.UserID;
          } () =>
          {
             var user = GetUser(userID);
             Assert.AreEqual(2, user.Friends.Count());
          });
       }
    }
