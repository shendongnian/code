    public class TestInput : IUserInput
    {
        public ReadInput()
        {
            return "This is dummy data";
        }
    }
    [Test]
    public void MyTest()
    {
        var testInput = new TestInput();
        var systemUnderTest = new YourClass(testInput);
        // ...
    }
