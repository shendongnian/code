    class Cat
    {
        private bool _initialized;
        public void Initialized()
        {
            _initialized = true;
        }
        [Pure]
        private bool IsInValidState()
        {
            // Disregard Invariant checking until the Initialized() method has been called
            if (!_initialized) return true;
            // Check the state of the class
            if (this.Age <= 0) return false;
            if (string.IsNullOrWhiteSpace(this.Name)) return false;
            return true;
        }
        public int Age { get; set; }
        public string Name { get; set; }
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            Contract.Invariant(IsInValidState());
        }
    }
