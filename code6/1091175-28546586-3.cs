    [assembly: Sandbox.TrapExceptionAspect]
    
    namespace Sandbox
    {
        using System;
        using System.Runtime.Serialization;
    
        using PostSharp.Aspects;
    
        public static class Program
        {
            public static void Main()
            {
                try
                {
                    Foo(2);
                }
                catch (Exception exception)
                {
                    while (exception != null)
                    {
                        Console.WriteLine(exception.Message);
                        Console.WriteLine(exception.StackTrace);
    
                        exception = exception.InnerException;
                    }
                }
    
                Console.ReadKey(true);
            }
    
            private static void Foo(int value)
            {
                Bar(value);
            }
    
            private static void Bar(int value)
            {
                if (value % 2 == 0)
                {
                    throw new Exception("Invalid value.");
                }
    
                Console.WriteLine("Hello, world.");
            }
        }
    
        [Serializable]
        public class TrapExceptionAspect : OnExceptionAspect
        {
            public override void OnException(MethodExecutionArgs args)
            {
            }
        }
    }
