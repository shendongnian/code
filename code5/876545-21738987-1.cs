    public class ClassWithMethods : IClassWithMethods
    {
        public virtual int Test1()
        {
            var value = this.Test2(); //Unittest should substitute with 5
            var businesslogic = value + 10; //The business logic
    
            return businesslogic;
        }
    
        public virtual int Test2()
        {
            return 10; //I try to mock this value away in the test. Don´t go here!
        }
    }
    [TestMethod]
    public void TestToTestClass()
    {
        //Arrange
    
        var instance = A.Fake<ClassWithMethods>();
    
        //Make calling Test2 return 5 and not 10.
        A.CallTo(() => instance.Test2()).Returns(5);
        
        // Make sure that Test1 on our fake calls the original ClassWithMethods.Test1
        A.CallTo(() => instance.Test1()).CallsBaseMethod();
    
        //Call the method 
        var sum = instance.Test1();
    
        //Assert if the business logic in the method works.
        Assert.AreEqual(15, sum);
    }
