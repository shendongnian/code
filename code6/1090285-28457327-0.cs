    class Test2<TBase, TDerived> where TDerived : class, TBase
    {
        private List<TDerived> m_X;
        public IEnumerable<TBase> GetEnumerable()
        {
            return m_X;
        }
    }
