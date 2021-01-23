    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GetPersonTest()
        {
            //Arrange
            Person p = new Person(0, "", "");      //note the change
    
            //Act
            Person result = p.GetPerson();
                
            //Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("John", result.FirstName);
            Assert.AreEqual("Dhoe", result.LastName);
        }
    }
