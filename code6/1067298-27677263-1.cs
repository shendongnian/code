    namespace MyService
    {
        [ServiceContract]
        public interface IPipeComm
        {
            [OperationContract]
            string PipeCommProc(string value);
        }
    
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]     
        public partial class MyService : ServiceBase, IPipeComm
        {
            public string PipeCommProc(string value)
            {
                return ("blah");
            }
    
            private readonly ServiceHost PipeHost;
    
            public MyService()
            {
                PipeHost = new ServiceHost(this, new Uri[] { new Uri("net.pipe://localhost") });
            }
        }
