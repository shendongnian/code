    class Test2<TBase, TDerived> where TDerived : TBase
    {
        private List<TDerived> m_X;
        public IEnumerable<TBase> GetEnumerable()
        {
            return m_X.Cast<TDerived>();
        }
    }
