    class MyClass
    {
      internal int Field;
    }
    struct MyStruct
    {
      internal int Field; // NB! Many people consider mutable structs evil
    }
    static class Test
    {
      static void Main()
      {
        var a = new MyClass();
        ChangeFieldOfMyClass_ByVal(a);
        Console.WriteLine(a.Field);
        var b = new MyStruct();
        ChangeFieldOfMyStruct_ByVal(b);
        Console.WriteLine(b.Field);
        var c = new MyClass();
        ChangeFieldOfMyClass_ByRef(ref c);
        Console.WriteLine(c.Field);
      
        var d = new MyStruct();
        ChangeFieldOfMyStruct_ByRef(ref d);
        Console.WriteLine(d.Field);
        var e = new MyClass();
        AssignToParameterMyClass_ByVal(e);
        Console.WriteLine(e.Field);
        var f = new MyStruct();
        AssignToParameterMyStruct_ByVal(f);
        Console.WriteLine(f.Field);
        var g = new MyClass();
        AssignToParameterMyClass_ByRef(ref g);
        Console.WriteLine(g.Field);
        var h = new MyStruct();
        AssignToParameterMyStruct_ByRef(ref h);
        Console.WriteLine(h.Field);
      }
      static void ChangeFieldOfMyClass_ByVal(MyClass p)
      {
        p.Field = 42;
      }
      static void ChangeFieldOfMyStruct_ByVal(MyStruct p)
      {
        p.Field = 42;
      }
      static void ChangeFieldOfMyClass_ByRef(ref MyClass p)
      {
        p.Field = 42;
      }
      static void ChangeFieldOfMyStruct_ByRef(ref MyStruct p)
      {
        p.Field = 42;
      }
      static void AssignToParameterMyClass_ByVal(MyClass p)
      {
        p = new MyClass { Field = 42, };
      }
      static void AssignToParameterMyStruct_ByVal(MyStruct p)
      {
        p = new MyStruct { Field = 42, };
      }
      static void AssignToParameterMyClass_ByRef(ref MyClass p)
      {
        p = new MyClass { Field = 42, };
      }
      static void AssignToParameterMyStruct_ByRef(ref MyStruct p)
      {
        p = new MyStruct { Field = 42, };
      }
    }
