    //Original Code
    class MyClass4
    {
        public bool DoAllHaveSomeProperty()
        {
            return m_instrumentList.All(m_filterExpression);
        }
        private IEnumerable<Instrument> m_instrumentList;
        private Predicate<Instrument> m_filterExpression;
    }
