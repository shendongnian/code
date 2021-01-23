    public class OperationContextSynchronizationContext : SynchronizationContext
    {
        private readonly OperationContext context;
        public OperationContextSynchronizationContext(IClientChannel channel) : this(new OperationContext(channel)) { }
        public OperationContextSynchronizationContext(OperationContext context)
        {
            OperationContext.Current = context;
            this.context = context;
        }
        public override void Post(SendOrPostCallback d, object state)
        {
            OperationContext.Current = context;
            d(state);
        }
    }
