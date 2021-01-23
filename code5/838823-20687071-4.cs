    namespace Other
    {
      using DatabaseCache;
    
      class DbcTestClass1
      {
        void M()
        {
          DatabaseCache.somePublicFlag = true;  // legal!
        }
      }
    }
