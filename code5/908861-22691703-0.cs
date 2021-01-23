    [Test]
    public void LoadUser()
    {
      this.RunTest(session =>
      {
        var user = new UserAccount("Mr", "Joe", "Bloggs");
        session.Save(user);
        return user.UserIDl
      }, id =>
      {
         var user = LoadMyUser(id);
         Assert.AreEqual("Mr", user.Title);
         // and so on...
      }
    }
