    var serviceFault = exc as FaultException<ExceptionDetail>;
            if (serviceFault != null)
            {
                if (serviceFault.Detail.Type.Equals(typeof(TimeoutException).FullName))
                {
                }
                else if serviceFault.Detail.Type.Equals(typeof(EndpointNotFoundException).FullName))
                {
                }
                .....
            }
