    [TestFixture]
    public class AccountTest
    {
       public Account underTest;
       [SetUp]
       public void setUp()
       {
         underTest = new Account();
       }
       [Test]
       public void TestLoginWithValidCredentials()
       { 
          bool isValid = underTest.Login('userName', 'password');         
          Assert.True(isValid );
       }
       [Test]
       public void TestLoginWithInValidCredentials()
       {
           bool isValid = underTest.Login('', '');         
           Assert.False(isValid );
       }
    }
