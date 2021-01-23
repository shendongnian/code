    class ProcessWrapper
    {
        private Process _process;
        public ProcessWrapper(Process process)
        {
            _process = process;
        }
        public override string ToString()
        {
            return _process.ToString() + " (" + _process.PrivateMemorySize64 / 1000000L + "M)";
        }
    }
