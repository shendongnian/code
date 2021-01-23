    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using System.Text;
    using System.Threading.Tasks;
    using System.ServiceModel;
    
    namespace SO21299236
    {
        class Program
        {
            static void Main(string[] args)
            {
                var address = new Uri("net.pipe://localhost/" + Guid.NewGuid());
                var service = new ServiceHost(typeof (MyService));
                var binding = new NetNamedPipeBinding(NetNamedPipeSecurityMode.None);
                var ep = service.AddServiceEndpoint(typeof(IMyService), binding, address);
                ep.Behaviors.Add(new MyBehavior() );
                service.Open();
    
                var factory = new ChannelFactory<IMyService>(binding, new EndpointAddress(address));
                var proxy = factory.CreateChannel();
                proxy.DoSomething();
    
                Console.WriteLine("Done.");
            }
        }
    
        internal class MyBehavior : IEndpointBehavior
        {
            public void Validate(ServiceEndpoint endpoint)
            {
            }
    
            public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
            {
            }
    
            public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
            {
                endpointDispatcher.DispatchRuntime.MessageInspectors.Add(new CustomMessageInspector());
            }
    
            public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
            {
            }
        }
    
        internal class CustomMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
            {
                return null;
            }
    
            public void BeforeSendReply(ref Message reply, object correlationState)
            {
                var prop = reply.Properties.FirstOrDefault(z => z.Key == "MyProperty");
                Console.WriteLine(prop.Value);
            }
        }
    
        [ServiceContract]
        interface IMyService
        {
            [OperationContract]
            void DoSomething();
        }
    
        class MyService : IMyService
        {
            public void DoSomething()
            {
                OperationContext.Current.OutgoingMessageProperties.Add("MyProperty", 1);
            }
        }
    }
