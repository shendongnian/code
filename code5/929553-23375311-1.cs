    public class Program
    {
    	public static void Main()
    	{
    		TestObject test = new TestObject();
    		Console.WriteLine(test.GetFieldAttr(() => test.testfld1).Text);
    		Console.WriteLine(test.GetFieldAttr(() => test.testfld2).Text);
    		Console.WriteLine(test.GetFieldAttr(() => test.testfld3).Text);
    	}
    }
