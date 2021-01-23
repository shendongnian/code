    class Foo
    {
      public dynamic Value { get; set; }
    }
    
    class FooHandler
    {
      public void Serialize(Foo foo)
      {
        SerializeField(foo.Value);
      }
    
      void SerializeField(int field)
      {
        Console.WriteLine("handle int");
      }
    
      void SerializeField<T>(T field)
      {
        throw new NotImplementedException("Serialization not implemented for type: " + typeof(T));
      }
    }
    
    class Program
    {
      [STAThread]
      static void Main(string[] args)
      {
        Foo f = new Foo();
        f.Value = 1;
    
        FooHandler handler = new FooHandler();
        handler.Serialize(f);
    
        Console.ReadKey();
      }
    }
