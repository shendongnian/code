    public interface IMyObj : IDisposable
    {
        string Name { get; set; }
    }
    public class MyObj : IMyObj
    {
        public virtual string Name { get; set; }
        
        public virtual void Dispose()
        {
            Name = string.Empty;
            GC.SuppressFinalize(this);
        }
    }
    public class NjModule : NinjectModule
    {
        public override void Load()
        {
            Bind<Requester>()
                .ToSelf()
                .InSingletonScope();
            
            Bind<IChildKernel>().ToSelf().InSingletonScope();
        }
    }
    public class NjChildKernelModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMyObj>()
                .To<MyObj>()
                .InCallScope();
        }
    }
    public class Requester
    {
        public List<IMyObj> RequestObjects(IChildKernel childKernel)
        {
            List<IMyObj> list = new List<IMyObj>();
            
            for(int i = 0; i < 10; i++) {
                var myObj = childKernel.Get<IMyObj>();
                myObj.Name = "abcdefghijklmnopqrstuvwxyz";
                list.Add(myObj);
            }
            
            return list;
        }
    }
    class Program
    {
        public static IKernel Kernel;
        
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello NInject!");
            
            // TODO: Implement Functionality Here
            
            Kernel = new StandardKernel(new NjModule());
            Kernel.Settings.ActivationCacheDisabled = true;
            
            var requester = Kernel.Get<Requester>();
            
            for (int i = 0; i < 100000000; i++) {
                
                var childKernel = new ChildKernel(Kernel, new NjChildKernelModule());
                childKernel.Settings.ActivationCacheDisabled = true;
                
                List<IMyObj> list =
                    requester.RequestObjects(childKernel);
                
                foreach (MyObj listItem in list) {
                    listItem.Dispose();
                }
                list.Clear();
                list = null;
                
                childKernel.Dispose();
            }
            
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);
        }
    }
