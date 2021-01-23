    public class OverloadDelegateList
    {
        readonly object target;
        readonly string methodName;
        List<InvokableMethod> methods;
        public OverloadDelegateList(Delegate firstOverload)
        {
            Debug.Assert(firstOverload != null);
            this.methods = new List<InvokableMethod>();
            this.target = firstOverload.Target;
            this.methodName = firstOverload.Method.Name;
            AddOverload(firstOverload);
        }
        public IEnumerable<InvokableMethod> InvokableMethods
        {
            get { return this.methods; }
        }
        public void AddOverload(Delegate d)
        {
            Debug.Assert(d != null);
            if (!Object.ReferenceEquals(d.Target, target))
                throw new ArgumentException();
            if (d.Method.Name != this.methodName)
                throw new ArgumentException();
            this.methods.Add(new InvokableMethod(d, (from p in d.Method.GetParameters() select p.ParameterType).ToArray()));
        }
        public object DynamicInvoke(params object[] args)
        {
            var signature = new MethodSignature((from a in args select a.GetType()).ToArray());
            var overload = this.methods.FirstOrDefault(m => m.Signature.Equals(signature));
            
            if (overload == null)
                throw new ArgumentException();
            return overload.InvokableOverload.DynamicInvoke(args);
        }
    }
****
    public class InvokableMethod
    {
        readonly MethodSignature signature;
        readonly Delegate invokableMethod;
        public InvokableMethod(Delegate invokableMethod, params Type[] types)
            :this(invokableMethod, new MethodSignature(types))
        {
        }
        public InvokableMethod(Delegate invokableMethod, MethodSignature signature)
        {
            Debug.Assert(invokableMethod != null);
            this.invokableMethod = invokableMethod;
            this.signature =signature;
        }
        public Delegate InvokableOverload { get { return this.invokableMethod; } }
        public MethodSignature Signature { get { return this.signature; } }
    }
