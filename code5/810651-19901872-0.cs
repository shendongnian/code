    class Program
    {
        static void Main(string[] args)
        {
            new A().Invoke();
            CallStack.Get().ToList().ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
    public class CallStack
    {
        private CallStack()
        {
            _callStack = new Stack<string>();
        }
        private static CallStack _singleton;
        private  Stack<string> _callStack;
        public static CallStack Get()
        {
            if (_singleton == null) _singleton = new CallStack();
            return _singleton;
        }
        public static void Push(string call)
        {
            Get()._callStack.Push(call);
        }
        public List<string> ToList()
        {
            return new List<string>(_callStack);
        }
    }
    public abstract class MethodBase
    {
        protected void Trace()
        {
            CallStack.Push(GetType().Name);
        }
        protected abstract void Operation();
        public void Invoke()
        {
            Trace();
            Operation();
        }
    }
    public class A : MethodBase
    {
        protected override void Operation()
        {
            new B().Invoke();
            new C().Invoke();
        }
    }
    public class B : MethodBase
    {
        protected override void Operation()
        {
            new B1().Invoke();
            new B2().Invoke();
        }
    }
    public class C : MethodBase
    {
        protected override void Operation()
        {
            new C1().Invoke();
            new C2().Invoke();
            new C3().Invoke();
        }
    }
    public class B1 : MethodBase
    {
        protected override void Operation() { }
    }
    public class B2 : MethodBase
    {
        protected override void Operation() { }
    }
    public class C1 : MethodBase
    {
        protected override void Operation() { }
    }
    public class C2 : MethodBase
    {
        protected override void Operation() { }
    }
    public class C3 : MethodBase
    {
        protected override void Operation(){}
    }
