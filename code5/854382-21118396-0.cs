    void Main()
    {
    	try
    	{
    		using (TestUsing t1 = new TestUsing("t1"), t2 = new TestUsing("t2"))
    		{
    		}
    	}
    	catch(Exception ex)
    	{
    		Console.WriteLine("catch");
    	}
    	finally
    	{
    		Console.WriteLine("done");
    	}
    	
    	/* outputs
    	
    		Construct: t1
    		Construct: t2
    		Dispose: t1
    		catch
    		done
    	
    	*/
    }
    
    public class TestUsing : IDisposable
    {
    	public string Name {get; set;}
    	
    	public TestUsing(string name)
    	{
    		Name = name;
    		
    		Console.WriteLine("Construct: " + Name);
    		
    		if (Name == "t2") throw new Exception();
    	}
    	
    	public void Dispose()
    	{
    		Console.WriteLine("Dispose: " + Name);
    	}
    }
