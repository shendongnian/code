    public class Customer : CustomerBase
    {
      // internals are visible to test
      internal string GenString()
      {
        // this actually composes a number of different properties 
        // from the parent, child and system properties
        return InfoPropertyNameGetter() + DateTime.Now.ToString() + "something else"; 
      }
      public virtual string InfoPropertyNameGetter(){
        retrn this.InfoProperty.Name;
      }
    }
    Mock<Customer> mock = new Mock<Customer>();
    mock.Setup(m => m.InfoPropertyNameGetter()).Returns("My custom value");
