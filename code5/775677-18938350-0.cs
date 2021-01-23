    static void Main(string[] args)
    {
      object foo = new MutableStruct {Foo = 123};
      Console.WriteLine(foo);
      Bar(foo);
      Console.WriteLine(foo);
    }
    
    static unsafe void Bar(object foo)
    {
      GCHandle h = GCHandle.Alloc(foo, GCHandleType.Pinned);
    
      MutableStruct* fp = (MutableStruct*)(void*)  h.AddrOfPinnedObject();
    
      fp->Foo = 789;
    }
