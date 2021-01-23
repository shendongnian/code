    using System;
    using System.ServiceModel;
    using System.ServiceModel.Description;
    using WcfQ.QServiceReference;
    
    namespace WcfQ
    {
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class QService : IQService
    {
        public void Foo()
        {
            throw new ApplicationException("Please catch this");
        }
    }
    [ServiceContract]
    public interface IQService
    {
        [OperationContract]
        void Foo();
    }
    class Program
    {
        static private QServiceClient client;
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(QService), new Uri("http://localhost:20001/q"));
            AddWsdlSupport(host);
            host.AddServiceEndpoint(typeof (IQService), new WSHttpBinding(SecurityMode.None), "");
            host.Open();
            client = new QServiceClient();
            client.BeginFoo(FooCallback, null);
            Console.WriteLine("ready");
            Console.ReadKey();
        }
        private static void FooCallback(IAsyncResult asyncResult)
        {
            try
            {
                client.EndFoo(asyncResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Got the exception: " + ex.Message);
            }
        }
        static void AddWsdlSupport(ServiceHost svcHost)
        {
            ServiceMetadataBehavior smb = svcHost.Description.Behaviors.Find<ServiceMetadataBehavior>();
            // If not, add one
            if (smb == null)
                smb = new ServiceMetadataBehavior();
            smb.HttpGetEnabled = true;
            smb.MetadataExporter.PolicyVersion = PolicyVersion.Policy15;
            svcHost.Description.Behaviors.Add(smb);
            // Add MEX endpoint
            svcHost.AddServiceEndpoint(
              ServiceMetadataBehavior.MexContractName,
              MetadataExchangeBindings.CreateMexHttpBinding(),
              "mex"
            );
            
        }
    }
