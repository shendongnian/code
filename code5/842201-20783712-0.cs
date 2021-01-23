    Class B {
      // Object to be used in locking.
      // It's private: we don't want to let anyone
      // interfere in our internal locking policy 
      // (so we do not use e.g. lock(this) etc)  
      private Object m_SyncObj = new Object();
    
      A a = new A();
    
      public void ResetA() {
        lock (m_SyncObj) {
          // A little bit strange lock block unless "a" is locked somewhere else as well
          a = null;
        }
      }
    ...
