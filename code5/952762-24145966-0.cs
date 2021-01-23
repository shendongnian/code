    [Serializable]
    public class Offline : OnMethodBoundaryAspect, IInstanceScopedAspect
    {
        [ImportMember("IsOffline", IsRequired = true)]
        public Property<bool> IsOffline;
        public override void OnEntry(MethodExecutionArgs args)
        {
            if (this.IsOffline.Get())
            {
                // ...
            }
        }
        // IInstanceScopedAspect implementation below:
        public object CreateInstance(AdviceArgs adviceArgs)
        {
            return this.MemberwiseClone();
        }
        public void RuntimeInitializeInstance()
        {
        }
    }
