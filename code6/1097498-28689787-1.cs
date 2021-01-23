      using ConsoleApplication1;
      namespace ConsoleApplication2
      {
         class Program
         {
             static void Main(string[] args)
             {
             }
         }
    class NewClass : MyAbsClass
    {
        public override string DoSomethingExternal()
        {
            throw new NotImplementedException();
        }
      }
     }
