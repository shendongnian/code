    public static class LogicalFlow
    {
        private static AsyncLocal<Stack> _asyncLogicalOperationStack;
        private static Stack AsyncLogicalOperationStack
        {
            get
            {
                if (_asyncLogicalOperationStack == null)
                {
                    _asyncLogicalOperationStack = new AsyncLocal<Stack> {Value = new Stack()};
                }
                return _asyncLogicalOperationStack.Value;
            }
        }
        public static Guid CurrentOperationId
        {
            get
            {
                return AsyncLogicalOperationStack.Count > 0
                    ? (Guid) AsyncLogicalOperationStack.Peek()
                    : Guid.Empty;
            }
        }
        public static IDisposable StartScope()
        {
            AsyncLogicalOperationStack.Push(Guid.NewGuid());
            return new Stopper();
        }
        private static void StopScope()
        {
            AsyncLogicalOperationStack.Pop();
        }
    }
