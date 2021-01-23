    internal class A
    {
        private static readonly _aLock = new Object();
    
        public void Do_A_Thing()
        {
            lock (_aLock)
            {
                GenericClass.DoSomething();
            }
        }
    } 
