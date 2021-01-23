    [TestClass]
    public class Timeouts
    {
        [TestMethod]
        public void Test()
        {
            Task.Factory.StartNew(() =>
            {
                var serverBinding = new NetTcpBinding();
                serverBinding.ReliableSession.Enabled = true;
                serverBinding.ReliableSession.InactivityTimeout = TimeSpan.FromSeconds(4);
                var host = new ServiceHost(typeof (MyService));
                host.AddServiceEndpoint(typeof (IMyService), serverBinding, "net.tcp://localhost:1234/service");
                host.Open();
            }).Wait();
            var clientBinding = new NetTcpBinding();
            clientBinding.ReliableSession.Enabled = true;
            var channelFactory = new ChannelFactory<IMyService>(clientBinding, "net.tcp://localhost:1234/service");
            var channelOne = channelFactory.CreateChannel();
            channelOne.MyMethod();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            channelOne.MyMethod();
            
            (channelOne as ICommunicationObject).Close();
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var channelTwo = channelFactory.CreateChannel();
            channelTwo.MyMethod();
            Thread.Sleep(TimeSpan.FromSeconds(6));
            channelTwo.MyMethod();
            (channelTwo as ICommunicationObject).Close();
        }
        [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
        public class MyService : IMyService
        {
            public void MyMethod()
            {
                Console.WriteLine("Hash: " + GetHashCode());
                Console.WriteLine("Session: " + OperationContext.Current.SessionId);
                Console.WriteLine();
            }
        }
        [ServiceContract]
        public interface IMyService
        {
            [OperationContract]
            void MyMethod();
        }
    }
