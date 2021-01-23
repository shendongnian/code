        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (DispatchOperation dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
            { 
                    dispatchOperation.ParameterInspectors.Add(new ParamInspector(this.Class));
            }
            endpointDispatcher.ChannelDispatcher.ErrorHandlers.Add(new CustromErrorHandler());
        }
