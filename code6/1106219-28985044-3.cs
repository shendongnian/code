    //First you will need to implement 2 interfaces
    //IDispatchMessageInspector or IClientMessageInspector and IServiceBehavior or IEndpointBehavior
    public class MustUnderstandMessageInspector : IDispatchMessageInspector
        {
            public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
            {
                //Here you can use the ref request(Remember it is a ref, careful what you do with it)
                //request is the message you just received
                SaveInDatabase(request);
                return null;
            }
            public void BeforeSendReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
            {
                //reply is a ref like request and it is the message you are sending
                throw new NotImplementedException();
            }
        }
    // To be able to implement your MessageInspector in your service you need to create a behavior.
    //this behavior will have to be added to your server.
    public class UnderstandBehavior : IServiceBehavior
        {
            void IServiceBehavior.AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, System.Collections.ObjectModel.Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
            {
                //throw new NotImplementedException();
            }
            public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
                //This will Add your inspector to every dispatcher inside serviceHostBase
                //you will have to use the one your service is on
                foreach (ChannelDispatcher chDisp in serviceHostBase.ChannelDispatchers)
                {
                    foreach (EndpointDispatcher epDisp in chDisp.Endpoints)
                    {
                        epDisp.DispatchRuntime.MessageInspectors.Add(new MustUnderstandMessageInspector());
                    }
                }
            }
            void IServiceBehavior.Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
            {
                //throw new NotImplementedException();
            }
        }
    }
