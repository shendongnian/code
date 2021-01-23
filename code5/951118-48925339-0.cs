    #if DEBUG
        public System.Delegate[] GetInvocationList()
        {
            return PropertyChanged?.GetInvocationList();
        }
    #endif
