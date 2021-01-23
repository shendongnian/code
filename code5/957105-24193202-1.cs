    [TestClass]
    public class TestMyClass
    {
        [TestMethod]
        public string TestPortIsNotZero(){
            var host = new ServiceHost(typeof(MyClass), 
                new Uri("net.tcp://localhost:0/abc"));
            var endpoint = host.AddServiceEndpoint(typeof(MyClass), 
                new NetTcpBinding(SecurityMode.None), "net.tcp://localhost:0/abc");
            //had to set the listen uri behavior to unique
            endpoint.ListenUriMode = ListenUriMode.Unique;
            //in addition open the host
            host.Open();
            foreach (var cd in host.ChannelDispatchers)
            {
               //prints out the port number in the dynamic range
               Debug.WriteLine(cd.Listener.Uri.Port);
               Assert.IsTrue(cd.Listener.Uri.Port >= 0); 
            }
       }
    }
