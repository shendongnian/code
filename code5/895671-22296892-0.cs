    using System;
    using System.IO;
    namespace ConsoleApp1
    {
        public sealed class Wrapper
        {
            public Wrapper(Action pre, Action<Exception> post)
            {
                _pre  = pre;
                _post = post;
            }
            public T Wrap<T>(Func<T> func)
            {
                try
                {
                    _pre();
                    T result = func();
                    _post(null);
                    return result;
                }
                catch (Exception exception)
                {
                    _post(exception);
                    throw;
                }
            }
            public void Wrap(Action action)
            {
                try
                {
                    _pre();
                    action();
                    _post(null);
                }
                catch (Exception exception)
                {
                    _post(exception);
                    throw;
                }
            }
            private readonly Action _pre;
            private readonly Action<Exception> _post;
        }
        public sealed class Demo
        {
            public Demo(Wrapper wrapper)
            {
                _wrapper = wrapper;
            }
            public string Name()
            {
                return _wrapper.Wrap(() => "This is a name");
            }
            public void Write(string textToWrite)
            {
                _wrapper.Wrap(() => _writer.Write(textToWrite));
            }
            public void ThrowsException()
            {
                _wrapper.Wrap(() => {throw new InvalidOperationException("Test");});
            }
            private readonly Wrapper      _wrapper;
            private readonly StreamWriter _writer = new StreamWriter(Console.OpenStandardOutput());
        }
        sealed class Program
        {
            private void run()
            {
                var wrapper = new Wrapper
                (
                    () => Console.WriteLine("Calling pre()"),
                    ex => Console.WriteLine("Calling post(), exception = " + ((ex != null) ? ex.Message : "<none>"))
                );
                Demo demo = new Demo(wrapper);
                Console.WriteLine("Name = " + demo.Name());
                demo.Write("Some text to write");
                demo.ThrowsException();
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
