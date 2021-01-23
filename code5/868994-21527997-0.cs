    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class SomeFirstClassName{}
        public class SomeSecondClassName{}
        public class Result {}
        public class Args
        {
            public Result Result;
            public Type   ElementType;
        }
        internal class Program
        {
            private Dictionary<Type, Func<Args, Result>> map = new Dictionary<Type, Func<Args, Result>>();
            private void run()
            {
                init();
                var args1 = new Args {ElementType = typeof(SomeFirstClassName)};
                var args2 = new Args {ElementType = typeof(SomeSecondClassName)};
                test(args1); // Calls GetResult<T> for Demo.SomeFirstClassName.
                test(args2); // Calls GetResult<T> for Demo.SomeSecondClassName.
            }
            private void test(Args args)
            {
                args.Result = map[args.ElementType](args);
            }
            private void init()
            {
                map.Add(typeof(SomeFirstClassName),  GetResult<SomeFirstClassName>);
                map.Add(typeof(SomeSecondClassName), GetResult<SomeSecondClassName>);
            }
            public Result GetResult<T>(Args args)
            {
                Console.WriteLine("GetResult<T>() called for T = " + typeof(T).FullName);
                return null;
            }
            private static void Main()
            {
                new Program().run();
            }
        }
    }
