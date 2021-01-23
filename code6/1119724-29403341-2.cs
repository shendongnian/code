    [TestFixture]
    public class TestCaseTest
    {
      [TestCase("ACCOUNT","SOCIAL")]
      public void Get_Test_Result(String a, String b)
      {
        Console.WriteLine("{0},{1}",a,b);   
      }
    }
