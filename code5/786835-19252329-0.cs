    class C_SQLSerResLibrary: IEnumerable<KeyValuePair<C_SQLServer, String>>
    {
        private Dictionary<C_SQLServer, String> m_dicSQLResLibrary;
        public IEnumerator<KeyValuePair<CSQLServer, String>> GetEnumerator()
        {
            return(IEnumerator<KeyValuePair<CSQLServer, String>>) m_dicSQLResLibrary. GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()//you missed this
        {
            return return this.GetEnumerator();
        }
     }
