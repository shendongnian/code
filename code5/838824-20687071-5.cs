    using DatabaseCache;
    
    namespace Other
    {
      class DbcTestClass2
      {
        void M()
        {
          var instance = new DatabaseCache.somePublicFlag();  // legal!
        }
      }
    }
