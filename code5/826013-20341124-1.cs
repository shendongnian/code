    [TestClass]
    public class Tests_That_Perform_Insert_Update_Or_Delete
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            //Here would go the code to restore the test database.
        }
        
        [TestMethod]
        public void Test1
        {
            //Perform logic.
            //Make assertions.
        }
        [TestMethod]
        public void Test2
        {
            //Perform some logic.
            //Make assertions.
        }
        
        [TestCleanup]
        public void MyClassCleanup()
        {
            //Here would go logic to drop the database.
        }
    }
