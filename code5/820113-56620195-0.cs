using System.Runtime.CompilerServices;
public static void Main(string[] args)
{
    Test().Wait();            
}
private static async Task Test()
{
    await Task.Yield();
    Log();
    await Task.Yield();
}
private static void Log([CallerMemberName]string methodName = "")
{
   var method = new StackTrace()
       .GetFrames()
       .Select(frame => frame.GetMethod())
       .FirstOrDefault(item => item.Name == methodName);
   Console.WriteLine("Log: {0}", method.DeclaringType + "." + method.Name);
}
This way I get method name with its full namespace path.
