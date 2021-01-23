    class Foo{
      private readonly List<int> list;
      public Foo(){ list = new List<int>();}
      
      public Test()
      {
        list = new List<int>(); // invalid; your reference is readonly
        list.add(5);//works, you are changing the object, but not touching it's reference
      }
    }
