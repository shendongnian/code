    class DoWork
    {
        private readonly Result _result;
        private readonly ReadWriteLockSlim _lock = new ReadWriteLockSlim();
        public DoWork()
        {
            _result = new Result();
        }
        public void Process()
        {
            // Execute Step 1
            Step1Result st1result = Step1();
            try
            {
                 _lock.EnterWriteLock();
                 _result.Step1Result = st1result;
            }
            finally
            {
                 _lock.ExitWriteLock();
            }
     
            Step2Result st2result = Step2();
             try
            {
                 _lock.EnterWriteLock();
                 _result.Step2Result = st2result;
            }
            finally
            {
                 _lock.ExitWriteLock();
            }
            // Other Steps ( long - running )
        }
        public Step1Result Step1()
        {
            // Long running step that can takes minutes
            return new Step1Result();
        }
        public Step2Result Step2()
        {
            // Long running step that can takes minutes
            return new Step2Result();
        }
        
        public Result GetCurrentResult()
        {
            try
            {
                 _lock.EnterReadLock();
                 return (Result)_result.MemberwiseCopy();
            }
            finally
            {
                 _lock.ExitReadLock();
            }
        }
    }
