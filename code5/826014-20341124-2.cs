    [TestClass]
    public class Tests_That_Perform_Only_Select   
    {
        [ClassInitialize]
        public static void MyClassInitialize()
        {
            //Here would go the code to restore the test database.
        }
        
        [TestMethod]
        public void Test1()
        {
            //Perform logic for retrieving some result set.
            //Make assertions.
        }
        [TestMethod]
        public void Test2()
        {
            //Perform logic for retrieving some result set.
            //Make assertions.
        }
        
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            //Here would go logic to drop the database.
        }
    }
