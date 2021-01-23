    static class Program
    {
      static void Main()
      {
        // test the instance method from 'TestObject', passing in a mock as 'mftbt' argument
        var testObj = new TestObject();
        var myMock = new Mock<IMyFaceToBeTested>();
        IMyArgFace magicalOut = new MyClass();
        myMock.Setup(x => x.MyMethod(out magicalOut)).Returns(true);
        testObj.TestMe(myMock.Object);
      }
    }
    class TestObject
    {
      internal void TestMe(IMyFaceToBeTested mftbt)
      {
        Console.WriteLine("Now code to be tested is running. Calling the method");
        IMyArgFace maf; // not assigned here, out parameter
        bool result = mftbt.MyMethod(out maf);
        Console.WriteLine("Method call completed");
        Console.WriteLine("Return value was: " + result);
        if (maf == null)
        {
          Console.WriteLine("out parameter was set to null");
        }
        else
        {
          Console.WriteLine("out parameter non-null; has runtime type: " + maf.GetType());
        }
      }
    }
    public interface IMyFaceToBeTested
    {
      bool MyMethod(out IMyArgFace maf);
    }
    public interface IMyArgFace
    {
    }
    class MyClass : IMyArgFace
    {
    }
