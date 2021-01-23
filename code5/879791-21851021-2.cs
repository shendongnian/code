    public class ExecuteDelegateOnPropertySetAspect : LocationInterceptionAspect
    {
        public ExecuteDelegateOnPropertySetAspect(Type methodOwner, string methodName, object[] arguments)
        {
            this.MethodOwner = methodOwner;
            this.MethodName = methodName;
            this.Arguments = arguments;
        }
        public Type MethodOwner { get; set; }
        public string MethodName { get; set; }
        public object[] Arguments { get; set; }
        public override void OnSetValue(LocationInterceptionArgs args)
        {
            // get method with the specified name from the specified owner type
            MethodInfo method = this.MethodOwner.GetMethod(this.MethodName);
            // method must be static, otherwise we would need an instance to call it
            if (method != null && method.IsStatic)
            {
                if (method.GetParameters().Length == this.Arguments.Length)
                {
                    // call the method with the given arguments
                    method.Invoke(null, this.Arguments);
                }
            }
            // execute the original setter code
            args.ProceedSetValue();
        }
    }
