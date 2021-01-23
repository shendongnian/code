    public class Action : Delegate
    {
        private object instance;
        private MethodInfo method;
        public void Invoke()
        {
            method.Invoke(instance, new object[]{});
        }
    }
