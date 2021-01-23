    [TestFixture]
    public class DataManagerTests
    {
    
        [Test]
        public void Process_Single_Processed()
        {
            // Arrange
            IData data = new SingleData();
            
            DataManager dataManager = new DataManager();
            
            // Act
            dataManager.Process(data);
            
            // Assert
            // check data processed correctly
            
        }
    }
