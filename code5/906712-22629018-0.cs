    public static class ContractEx
    {
        [ContractAbbreviator]
        public static void StringNullOrEmpty(string s, string parameterName)
        {
            Contract.Requires<ArgumentNullException>(s != null, parameterName);
            Contract.Requires<ArgumentException>(s.Length != 0, parameterName);
            Contract.Requires(!String.IsNullOrEmpty(s));  // required for static code analysis
        }
    }
