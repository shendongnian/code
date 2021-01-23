    [Test]
    public void LoadUser()
    {
      this.RunTest(session => // the NH/EF session to attach the objects to
      {
        var user = new UserAccount("Mr", "Joe", "Bloggs");
        session.Save(user);
        return user.UserID;
      }, id => // the ID of the entity we need to load
      {
         var user = LoadMyUser(id); // load the entity
         Assert.AreEqual("Mr", user.Title); // test your properties
         Assert.AreEqual("Joe", user.Firstname);
         Assert.AreEqual("Bloggs", user.Lastname);
      }
    }
