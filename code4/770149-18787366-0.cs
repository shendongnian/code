    [AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class HashAlgorithmAttribute : Attribute
    {
        readonly string algorithm;
        public HashAlgorithmAttribute(string algorithm)
        {
            this.algorithm = algorithm;
        }
        public string Algorithm
        {
            get { return algorithm; }
        }
    }
