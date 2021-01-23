    class C
    {
      void M()
      {
        Foo fooInstance = new Foo();
        // the variable is "definitely assigned" and can be read (copied, passed etc)
        // consider using the 'var' keyword above!
      }
    }
    class C
    {
      void M()
      {
        Foo fooInstance;
        // the variable is not "definitely assigned", you cannot acquire its value
        // it needs to be assigned later (or can be used as `out` parameter)
      }
    }
