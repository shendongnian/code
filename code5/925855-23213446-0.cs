    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Configuration;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;
    using log4net;
    namespace Server.Web
    {
        public class WebHttpWithErrorHandlingElement : BehaviorExtensionElement
        {
            public class WebHttpWithErrorHandlingBehavior : WebHttpBehavior
            {
                internal sealed class WebHttpErrorHandler : IErrorHandler
                {
                    private static readonly ILog logger = LogManager.GetLogger(typeof (WebHttpErrorHandler));
                    public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
                    {
                        var exception = new FaultException("Web Server error encountered. All details have been logged.");
                        var messageFault = exception.CreateMessageFault();
                        fault = Message.CreateMessage(version, messageFault, exception.Action);
                    }
                    public bool HandleError(Exception error)
                    {
                        logger.Error(string.Format("An error has occurred in the Web service {0}", error));
                        return !(error is FaultException);
                    }
                }
                protected override void AddServerErrorHandlers(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
                {
                    base.AddServerErrorHandlers(endpoint, endpointDispatcher);
                    endpointDispatcher.DispatchRuntime.ChannelDispatcher.ErrorHandlers.Add(new WebHttpErrorHandler());
                }
            }
            public WebHttpWithErrorHandlingElement()
            {
            }
            public override Type BehaviorType
            {
                get { return typeof (WebHttpWithErrorHandlingBehavior); }
            }
            protected override object CreateBehavior()
            {
                return new WebHttpWithErrorHandlingBehavior();
            }
        }
    }
