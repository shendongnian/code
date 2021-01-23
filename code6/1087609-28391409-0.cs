    async void Main()
    {
    	Foo f = new Foo();
    	Task s = await f.Bar();	
    	Console.WriteLine("Done");
    }
    
    public class Foo
    {
    	public Foo()
    	{
    	}
    	//recursive tail function
    	public async Task<Task> Bar()
    	{
            //enter your code here
            doSomething();
    		//Change this to what time you desire
    		await Task.Delay(1000);
    		return Bar();
    	}
    }
