    public class SomeClass
    {
        private static Action<string> cachedAction;
        public Action<string> SomeAction { get; set; }
    
        public SomeClass()
        {
            SomeAction = GetSomeAnonymousMethod();
        }
    
        private Action<string> GetSomeAnonymousMethod()
        {
            Action<string> action = cachedAction;
            if (action == null)
            {
                action = AnonymousMethodImplementation;
                cachedAction = action;
            }
            return action;
        }
        private static void AnonymousMethodImplementation(string text)
        {
            Console.WriteLine(text);
        }
    }
