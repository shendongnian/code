    public class OverloadDelegateList
    {
        readonly object target;
        List<InvokableMethod> methods;
        public OverloadDelegateList(Object target)
        {
            Debug.Assert(target != null);
            this.methods = new List<InvokableMethod>();
            this.target= target;
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
****
    public class MethodSignature: IEquatable<MethodSignature>
    {
        readonly List<Type> signature;
        public MethodSignature(params Type[] types)
        {
            this.signature = types.ToList();
        }
        public IEnumerable<Type> Signature { get { return this.signature; } }
        public override bool Equals(object obj)
        {
            return this.Equals(obj as MethodSignature);
        }
        public bool Equals(MethodSignature other)
        {
            if (object.ReferenceEquals(other, null))
                return false;
            if (other.signature.Count != this.signature.Count)
                return false;
            for (int i = 0; i < this.signature.Count; ++i)
            {
                if (this.signature[i] != other.signature[i])
                    return false;
            }
            return true;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 0;
                if (this.signature != null)
                {
                    foreach (var t in this.signature)
                    {
                        hash ^= t.GetHashCode();
                    }
                }
                return hash;
            }
        }
    }
