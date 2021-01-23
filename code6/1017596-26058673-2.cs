    public sealed class ReadWriteTest: ITest<ReadWriteAction>
    {
        public void SetActions(IEnumerable<ReadWriteAction> actions)
        {
            _actions = actions;
        }
        public IEnumerable<ReadWriteAction> Actions
        {
            get
            {
                return _actions;
            }
        }
        private IEnumerable<ReadWriteAction> _actions = Enumerable.Empty<ReadWriteAction>();
    }
