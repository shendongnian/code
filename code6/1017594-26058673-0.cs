    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        // The basic IAction interface.
        public interface IAction
        {
            void Execute();
        }
        // Some sample implementations of IAction.
        public sealed class ReadAction: IAction
        {
            public void Execute()
            {
                Console.WriteLine("ReadAction");
            }
        }
        public sealed class ReadWriteAction: IAction
        {
            public void Execute()
            {
                Console.WriteLine("ReadWriteAction");
            }
        }
        public sealed class GenericAction: IAction
        {
            public void Execute()
            {
                Console.WriteLine("GenericAction");
            }
        }
        // The base ITest interface. 'out T' makes it covariant on T.
        public interface ITest<out T> where T: IAction
        {
            IEnumerable<T> Actions
            {
                get;
            }
        }
        // A ReadWriteTest class.
        public sealed class ReadWriteTest: ITest<IAction>
        {
            public ReadWriteTest(IEnumerable<ReadWriteAction> actions)
            {
                _actions = actions;
            }
            public IEnumerable<IAction> Actions
            {
                get
                {
                    return _actions;
                }
            }
            private readonly IEnumerable<ReadWriteAction> _actions;
        }
        // A ReadTest class.
        public sealed class ReadTest: ITest<ReadAction>
        {
            public ReadTest(IEnumerable<ReadAction> actions)
            {
                _actions = actions;
            }
            public IEnumerable<ReadAction> Actions
            {
                get
                {
                    return _actions;
                }
            }
            private readonly IEnumerable<ReadAction> _actions;
        }
        // A GenericTest class.
        public sealed class GenericTest: ITest<IAction>
        {
            public GenericTest(IEnumerable<IAction> actions)
            {
                _actions = actions;
            }
            public IEnumerable<IAction> Actions
            {
                get
                {
                    return _actions;
                }
            }
            private readonly IEnumerable<IAction> _actions;
        }
        internal class Program
        {
            private static void Main()
            {
                // This demonstrates that we can pass the various concrete classes which have
                // different IAction types to a single test method which has a parameter of
                // type ITest<IAction>.
                var readActions = new[]
                {
                    new ReadAction(),
                    new ReadAction()
                };
                var test1 = new ReadTest(readActions);
                test(test1);
                var readWriteActions = new[]
                {
                    new ReadWriteAction(),
                    new ReadWriteAction(),
                    new ReadWriteAction()
                };
                var test2 = new ReadWriteTest(readWriteActions);
                test(test2);
                var genericActions = new[]
                {
                    new GenericAction(),
                    new GenericAction(),
                    new GenericAction(),
                    new GenericAction()
                };
                var test3 = new GenericTest(genericActions);
                test(test3);
            }
            // A generic test method.
            private static void test(ITest<IAction> data)
            {
                foreach (var action in data.Actions)
                {
                    action.Execute();
                }
            }
        }
    }
