    interface IFaceA
    {
        void MethodA();
    }
    interface IFaceB
    {
        void MethodB();
    }
    class MultiFaceProxy : RealProxy, IRemotingTypeInfo
    {
        public MultiFaceProxy()
            :base(typeof(IFaceA)) {}
        public bool CanCastTo(Type fromType, object o)
        {
            return fromType == typeof(IFaceA) || fromType == typeof(IFaceB);
        }
        public string TypeName
        {
            get { return GetProxiedType().FullName; }
            set { throw new NotSupportedException(); }
        }
        public override IMessage Invoke(IMessage msg)
        {
            // invoke logic
            return null;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MultiFaceProxy proxy = new MultiFaceProxy();
            IFaceA ifa = (IFaceA) proxy.GetTransparentProxy();
            // The following now also works thanks to CanCastTo()
            IFaceB ifb = (IFaceB)ifa;
         }
    }
