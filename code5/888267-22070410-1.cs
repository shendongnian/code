    [TestMethod]
    public void Result_WithValidInput_CallsValidate
    {
        //used the MethodUnderTest_Condition_ExpectedResult naming convention
        //Arrange
        IClass2 mockClass2;
        //TODO initialise mockClass2 with an a fake object using isolation framework, to return the relevant result to stop the code from falling over during test execution.
        Class1 class1UnderTest = new Class1(mockClass2);
    
        //Act
        class1UnderTest.Result(1);
        //Assert
        //TODO use methods from isolation framework to assert that mockClass2.Validate() was called with the correct argument
    }
