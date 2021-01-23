    internal sealed class ConditionVariablePattern {
      private readonly Object m_lock = new Object();
      private Boolean m_condition = false;
      public void Thread1() {
        Monitor.Enter(m_lock); // Acquire a mutual-exclusive lock
        // While under the lock, test the complex condition "atomically"
        while (!m_condition) {
        // If condition is not met, wait for another thread to change the condition
           Monitor.Wait(m_lock); // Temporarily release lock so other threads can get it
        }
        // The condition was met, process the data...
        Monitor.Exit(m_lock); // Permanently release lock
     }
     public void Thread2() {
        Monitor.Enter(m_lock); // Acquire a mutual-exclusive lock
       // Process data and modify the condition...
       m_condition = true;
       // Monitor.Pulse(m_lock); // Wakes one waiter AFTER lock is released
       Monitor.PulseAll(m_lock); // Wakes all waiters AFTER lock is released
       Monitor.Exit(m_lock); // Release lock
      }
    }
