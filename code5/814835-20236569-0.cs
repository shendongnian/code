    class AnotherAppDomainPluginBuilder<T> : MarshalByRefObject
        where T : new()
    {
        T Result { get; set; }
        public void Create()
        {
            LoadRelevantDlls();
            this.Result = new T();
        }
        void LoadRelevantDlls()
        {
            // load whatever DLLs in whatever way you would like to
        }
    }
