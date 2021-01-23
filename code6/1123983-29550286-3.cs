    public class HappyUserRights: UserRights
    {
         public override string LookupNameByID(string id)
         {
             return "yay!";
         }
    }
    [Fact]
    public void LookupNameByID_ReturnsResultOfUserRightsCall()
    {
       //this test will fail if an exception is thrown, thus proving that GetName doesn't handle exceptions correctly.
       var sut = new UserService(new HappyUserRights()); 
       var actual = sut.GetName("12345");
       Assert.Equal("yay!",actual);
    }
