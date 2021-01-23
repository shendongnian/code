    public class CommandRestClientTest
    {
        const string testServerAddress = "localhost:8080";
    
        [Fact]
        public void TestSomeMethod()
        {
            CommandRestClient commandRestClient = new CommandRestClient(testServerAddress);
            //test, assert etc
        }
    }
       
