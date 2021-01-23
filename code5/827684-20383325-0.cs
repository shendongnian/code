    public class Class2
    {
    	public Class2()
    	{
    		Class1 c1 = new Class1();
    		Console.WriteLine(c1.Id);
    	}                
    
    	private class Class1
    	{
    		public int Id { get; set; }
    	}
    }
