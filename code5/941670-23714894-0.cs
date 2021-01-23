        public void Dispose()
        {
            TellMinionsTo(minion=>minion.Dispose());
        }    
        private void TellMinionsTo(Action<ManagableClass> doSomething)
        {
            foreach (ManagableClass minion in minions)
            {
                 doSomething(minion);
            }
        }
