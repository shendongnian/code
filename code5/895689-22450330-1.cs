        protected override bool CheckAccessCore(OperationContext operationContext)
        {
            string action = operationContext.IncomingMessageHeaders.Action;
            DispatchOperation operation = operationContext.EndpointDispatcher.DispatchRuntime.Operations.FirstOrDefault(o => o.Action == action);
            Type hostType = operationContext.Host.Description.ServiceType;
            MethodInfo method = hostType.GetMethod(operation.Name);
            var myCustomAttributeOnMethod = method.GetCustomAttributes(true).Where(a => a.GetType() == typeof (MyCustomAttribute)).Cast<MyCustomAttribute>();
        .
        .
        .
        }        
