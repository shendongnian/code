    public class RestPerformanceInterceptor : IInterceptionBehavior
    {
        public bool WillExecute { get { return true; } }
    
        public IEnumerable<Type> GetRequiredInterfaces()
        {
            return new[] { typeof(IA) };
        }
    
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            var behaviorDelegate = getNext();
    
            StartInNewTask(behaviorDelegate.Invoke(input, getNext));
    		
            return new Mock<IMethodReturn>();
        }
    }
