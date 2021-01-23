    [Fact]
    public void LookupNameByID_WhenUserRightsThrowsException_DoesNotReThrow()
    {
       //this test will fail if an exception is thrown, thus proving that GetName doesn't handle exceptions correctly.
       var sut = new UserService(new ExplodingUserRights()); <-Look, no DatabaseContext!
       sut.GetName("12345");
    }
