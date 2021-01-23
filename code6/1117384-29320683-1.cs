    using System;
    using System.Threading.Tasks;
    
    public class MyApp
    {
        public static void Main()
        {
    		Console.WriteLine("1. MyApp calls camera capture.");
            CameraCaptureAsync().Wait();
        }
    
        public async static Task CameraCaptureAsync()
        {
    		Console.WriteLine("2. That calls callbackFunction");
            var task = CallbackFunction();
    		Console.WriteLine("4. In the meantime.");
    		Console.WriteLine("5. Do some other stuff. ");
    		await task;
    		Console.WriteLine("7. Process the " + task.Result);
    		DoMoreStuff();
        }
    
        public async static Task<string> CallbackFunction()
        {
    		Console.WriteLine("3. Which takes a picture.");
            await Task.Delay(100);
    		Console.WriteLine("6. After the callback functions completes");
    		return "Photograph";
        }
    
        public static void DoMoreStuff()
        {
            Console.WriteLine("8. Do more stuff.");
        }
    }
