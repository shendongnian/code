    class Program
    {
         private static ManualResetEventSlim _manualResetEventSlim;
         static void Main(string[] args)
         {
            using(var host = new ServiceHost(typeof(XServer), new Uri("net.pipe://localhost")))
            {
              host.AddServiceEndpoint(typeof(IXServer), new NetNamedPipeBinding(), "XServer");
              host.Open();      
              _manualResetEventSlim.Wait(); //This will **block** the application thread, But its not supposed to block your WCF Service host thread. 
            }
    }
