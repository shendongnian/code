    class C_SQLSerResLibrary: IEnumerable<KeyValuePair<C_SQLServer, String>>
    {
        private Dictionary<C_SQLServer, String> m_dicSQLResLibrary;
        public IEnumerator<KeyValuePair<CSQLServer, String>> GetEnumerator()
        {
            return m_dicSQLResLibrary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()//you missed this
        {
            return this.GetEnumerator();
        }
     }
