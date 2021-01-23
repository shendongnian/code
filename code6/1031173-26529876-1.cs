        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, 
            System.ServiceModel.IClientChannel channel, 
            System.ServiceModel.InstanceContext instanceContext) {
            if(AuthenticationNeeded()){ ... }
        }
        public bool AuthenticationNeeded() {
            // 1) Get the current operation's description
            OperationDescription od = GetOperationDescription(OperationContext.Current);
            // 2) Check if the service operation is annotated with the [RequiresAuth] attribute
            Type contractType = od.DeclaringContract.ContractType;
            object[] attr = contractType.GetMethod(od.Name).GetCustomAttributes(typeof(RequiresAuthAttribute), false);
            if (attr == null || attr.Length == 0) return false;
            return true;
        }
        // See http://www.aspnet4you.com/wcf/index.php/2013/01/30/message-interception-auditing-and-logging-at-wcf-pipeline/ 
        private OperationDescription GetOperationDescription(OperationContext operationContext) {
            OperationDescription od = null;
            string bindingName = operationContext.EndpointDispatcher.ChannelDispatcher.BindingName;
            string methodName;
            if (bindingName.Contains("WebHttpBinding")) {
                //REST request
                methodName = (string)operationContext.IncomingMessageProperties["HttpOperationName"];
            }
            else {
                //SOAP request
                string action = operationContext.IncomingMessageHeaders.Action;
                methodName = operationContext.EndpointDispatcher.DispatchRuntime.Operations.FirstOrDefault(o => o.Action == action).Name;
            }
            EndpointAddress epa = operationContext.EndpointDispatcher.EndpointAddress;
            ServiceDescription hostDesc = operationContext.Host.Description;
            ServiceEndpoint ep = hostDesc.Endpoints.Find(epa.Uri);
            if (ep != null) {
                od = ep.Contract.Operations.Find(methodName);
            }
            return od;
        }
