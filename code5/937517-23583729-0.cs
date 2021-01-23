    namespace Exceptions
    {
        class ExceptionTester
        {
            public void Run()
            {
                ThrowSecondException();
            }
            public void DoSomething()
            {
                DoMore();
            }
            public void DoMore()
            {
                ThrowFirstException();
            }
            public void ThrowFirstException()
            {
                throw new FooException();
            }
            public void ThrowSecondException()
            {
                try
                {
                    DoSomething();
                }
                catch (FooException e)
                {
                    throw new BarException("derp", e);
                }
            }
        }
        class FooException : Exception
        {
        
        }
        class BarException : Exception
        {
            public BarException(string msg, Exception inner) : base(msg, inner)
            {
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                var tester = new ExceptionTester();
                tester.Run();
            }
        }
    }
