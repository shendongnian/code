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
    [TearDown]
    public void TearDown()
    {
       this.TearDownDatabase();
    }
