    public class ServiceGlue
    {
        private static ServiceGlue instance = null;
        public static ServiceGlue Instance
        {
            get
            {
                if (instance == null)
                    instance = new ServiceGlue();
                 return instance;
             }
         }
        public Helper helper { get; set; }
    }
    [ServiceContract]    
    public interface IMyService
    {
        [OperationContract(IsOneWay = true)]
        void DoSomethingCool();
    }
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode =     ConcurrencyMode.Multiple)]
    class MyService : IMyService 
    {
        private IHelper helper;
        public MyService()
        {
           // use an intermidiary singleton to join the objects
           helper = ServiceGlue.Instance.Helper();
        }
        void DoSomethingCool()
        {
           // How do I pass an instance of helper to MyService so I can use it here???
           helper.HelperMethod();
        }
    }
