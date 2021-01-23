    void Main()
    {
    	Fail fail = new Fail();
    	int value = 123;
    	Thread t = new Thread(fail.DoWork); // same as: new Thread(new ParameterizedThreadStart(fail.DoWork));
    	t.Start(value);
    }
    
    public class Fail
    {
      public void DoWork(object value)
      {
      	Console.WriteLine("value: {0}", value);
      }
    }
