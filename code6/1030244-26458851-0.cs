    public interface IDoable {
      int Value { get; set; }
      void Foo();
    }
   
    public static class DoableWrapper {
      private MyDoable : IDoable {
        public int Value { get;set; }
        public void Foo() {
        }
      }
      private static IDoable s_Doable = new MyDoable();
      public static IDoable Instance {
        get { return s_Doable; }
      }
    }
