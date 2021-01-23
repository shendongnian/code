    public TestProperties : SingleSetup
    {
      public int UserID {get;set;}
    
      public override DoSetup(ISession session)
      {
        var user = new User("Joe", "Bloggs");
        session.Save(user);
        this.UserID = user.UserID;
      }
    [Test]
    public void TestLastname()
    {
         var user = LoadMyUser(this.UserID); // load the entity
         Assert.AreEqual("Bloggs", user.Lastname);
    }
    [Test]
    public void TestFirstname()
    {
         var user = LoadMyUser(this.UserID);
         Assert.AreEqual("Joe", user.Firstname);
    }
