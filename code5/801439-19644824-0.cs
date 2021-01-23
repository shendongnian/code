    class DelegateDisposable : IDisposable
    {
        private readonly Action m_dispose;
        public DelegateDisposable(Action onDispose)
        {
            m_dispose = onDispose;
        }
        public override void Dispose()
        {
            m_dispose();
        }
    }
