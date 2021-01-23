    [SetUp]
    public void Setup()
    {
      this.SetupTest(session => // the NH/EF session to attach the objects to
      {
        var user = new UserAccount("Mr", "Joe", "Bloggs");
        session.Save(user);
        this.UserID =  user.UserID;
      });
    }
    [Test]
    public void TestTitle()
    {
         var user = LoadMyUser(this.UserID); // load the entity
         Assert.AreEqual("Mr", user.Title);
    }
    [Test]
    public void TestFirstname()
    {
         var user = LoadMyUser(this.UserID);
         Assert.AreEqual("Joe", user.Firstname);
    }
    [Test]
    public void TestLastname()
    {
         var user = LoadMyUser(this.UserID);
         Assert.AreEqual("Bloggs", user.Lastname);
    }
    [TearDown]
    public void TearDown()
    {
       this.TearDownDatabase();
    }
