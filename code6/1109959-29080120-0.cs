    [TestClass]
    public class Tests
    {
       [TestMethod]
       public void DriveInfoTest()
       {
           // set up
           DriveUnit uut = new DriveUnit();
           // run
           var result = uut.GetInfo();
          // verify
          Assert.IsNotNull(result, "Get Info did not return an object.");
       }
    }
