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
       [Test]
       //Assert Expected Lockout exception here
       public void TestLockoutByPassingInValidCredentialsMoreThan5Times()
       {
          
           for (int i =0; i< 5; i++)
           {     
              bool isValid = underTest.Login('', '');    
              Assert.False(isValid );     
           }           
            // the system should throw an exception about lockout
            underTest.Login('', ''); 
       }      
       [Test]
       public void TestCreateAccount()
       {
          //Register event can directly call this method
          bool isCreated = underTest.Create(/*User Object*/);
          Assert.True(isCreated );
       }
       [Test]
       public void TestLogout()
       {
          bool success = underTest.Logout('userName');          
          Assert.True(success);          
       }
       [Test]
       public void TestReset()
       {
          // both Unlock and RecoverPassword event can share this method
          bool success = underTest.Reset('userName');          
           // mock the password reset system and return the expected value like 'BSy6485TY'
          Assert.AreEqual('BSy6485TY', password);
       }       
    }
