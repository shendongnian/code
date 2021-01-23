    [TestCase("")]
    [TestCase(null)]
    public class SomeTest(string stringValue)
    {
       Assert.Throws<ArgumentException>(()=> CheckIfNullOrEmpty(stringValue));
    }
    
    public void CheckIfNullOrEmpty(string val)
    {
       if(string.IsNullOrEmpty(val))
       {
           throw new ArgumentException();
       }
    }
