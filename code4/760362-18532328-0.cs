      public interface IBusinessClass {
        int DoWork();
      }
    
      public class BusinessClass : IBusinessClass
      {
        public int DoWork()
        {
          return 10;
        }
      }
      public interface IBusinessClass2
      {
        int DoWork2();
      }
    
      public class BusinessClass2 : IBusinessClass2
      {
        public int DoWork2()
        {
          return 20;
        }
      }
      public class Consumer
      {
        public IBusinessClass2 BusinessClass2 { get; set; }
    
        [Inject]
        public IBusinessClass BusinessClass { get; set; }
    
        public Consumer(IBusinessClass2 businessClass2)
        {
          BusinessClass2 = businessClass2;
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          IKernel kernel = new StandardKernel();
          kernel.Bind<IBusinessClass>()
                .To<BusinessClass>();
          kernel.Bind<IBusinessClass2>()
                .To<BusinessClass2>();
    
          Consumer c = kernel.Get<Consumer>();
          Console.WriteLine(c.BusinessClass.DoWork());
          Console.WriteLine(c.BusinessClass2.DoWork2());
          Console.ReadKey();
        }
      }
