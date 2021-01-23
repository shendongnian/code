    namespace N
    {
      public static Tree TheTree = new Tree();  // ILLEGAL (not inside a class)!
    }
    namespace N
    {
      class YourClass
      {
        public static Tree TheOneTree = new Tree();  // OK, static
        public Tree TheOtherTree = new Tree();  // OK, instance
        void Method()
        {
          var theUltimateTree = new Tree();  // OK, local variable
          ...
        }
      }
    }
