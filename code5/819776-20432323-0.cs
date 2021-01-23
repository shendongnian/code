    [Serializable]
    [MulticastAttributeUsage(MulticastTargets.Method, Inheritance = MulticastInheritance.None)]
    public class MyClassSwapperAttribute : MethodInterceptionAspect, IInstanceScopedAspect
    {
        private readonly Type cuckooType;
        
        [NonSerialized] private object cuckooEgg;
        public MyClassSwapperAttribute(Type cuckooType)
        {
            this.cuckooType = cuckooType;
        }
        private MyClassSwapperAttribute()
        {
            // this creates an "empty" aspect instance applied on the cuckoo's egg itself
        }
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            if (adviceArgs.Instance.GetType() == cuckooType)
                return new MyClassSwapperAttribute();
            
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
            if (this.cuckooType == null)
                return;
            
            // for each instance of the target class we create a new cuckoo's egg instance
            this.cuckooEgg = Activator.CreateInstance(cuckooType);
        }
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            if (this.cuckooEgg == null)
            {
                base.OnInvoke(args);
            }
            else
            {
                // delegate the method invocation to the cuckoo's egg, that derives from the target class
                args.ReturnValue = args.Method.Invoke(this.cuckooEgg, args.Arguments.ToArray());
            }
        }
    }
