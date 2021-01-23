    using System;
    using System.Threading.Tasks;
    					
    public class MyApp
    {
    	public static void Main()
    	{
    		CameraCaptureAsync().Wait();
    	}
    	
    	public async static Task CameraCaptureAsync()
    	{
    		Console.WriteLine("MyApp calls camera capture.");
    		
    		var result = await CallbackFunction();
    		
    		Console.WriteLine(result);
    		
    		DoMoreStuff();
    		
    	}
    	
    	public async static Task<string> CallbackFunction()
    	{
    		Console.WriteLine("That calls callbackFunction");
    		await Task.Delay(10);
    		return "After the callback functions completes...";
    	}
    	
    	public static void DoMoreStuff()
    	{
    		Console.WriteLine("...do more stuff.");
    	}
    }
