    class BusinessLogic
    {
        // To avoid the possibility of a deadlock, prevent external code from
        // ever acquiring this lock by making the lock target private.
        private readonly object lockTarget = new object();
    
        void Foo()
        {
            lock(lockTarget)
            {
                // your code here
            }
        }
    }
