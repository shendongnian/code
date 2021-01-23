    public class SimpleMonitor
    {
        private int m_LockState = 0;
    
        public void Enter()
        {
            int iterations = 0;
            while (!TryEnter())
            {
                if (iterations < 10) Thread.SpinWait(4 << iterations);
                else if (iterations % 20 == 0) Thread.Sleep(1);
                else if (iterations % 10 == 0) Thread.Sleep(0);
                else Thread.Yield();
                iterations++;
            }
        }
    
        public void Exit()
        {
            if (!TryExit())
            {
                throw new SynchronizationLockException();
            }
        }
    
        public bool TryEnter()
        {
            return Interlocked.CompareExchange(ref m_LockState, 1, 0) == 0;
        }
    
        public bool TryExit()
        {
            return Interlocked.CompareExchange(ref m_LockState, 0, 1) == 1;
        }
    }
