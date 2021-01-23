    class Program
    {
        void Main(string[] args)
        {
            var c = new MyClass();
            Console.WriteLine("Waiting ...");
    	c.AccessTheWeb("http://www.google.com").Wait();
    		              
        }
    
    }	
    	public class MyClass
    	{
    	    public async Task AccessTheWeb(string url)
    	    {
    	        var result = await GetUrl(url);
    	
    	        Console.Write(result);
    	    }
    	
    	    public async Task<string> GetUrl(string url)
    	    {
    	        string result;
    	
    	        using (var client = new HttpClient())
    	        {
    	            result = await client.GetStringAsync(url);
    	        }
    	
    	        return result; // why did you use "Did async task" ?
    	    }
    	}
    	
