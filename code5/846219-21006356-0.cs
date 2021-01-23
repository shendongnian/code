    public class operationdispatcher : IDispatchMessageInspector
    {
        List<Type> MyAttrybutes = new List<Type>() { typeof(behaviorattribute) };
        public object AfterReceiveRequest(ref System.ServiceModel.Channels.Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            var serviceType = instanceContext.Host.Description.ServiceType;
            var operationName = OperationContext.Current.IncomingMessageHeaders.Action;
            var methodName = operationName.Substring(operationName.LastIndexOf("/") + 1);
            var method = serviceType.GetMethods().Where(m => m.Name == methodName && m.IsPublic).SingleOrDefault();
            var attributes = method.GetCustomAttributes(true).Where(a => MyAttrybutes.Contains(a.GetType()));
            foreach (var attribute in attributes)
            {
                // you might want to instantiate an attribute and do something
            }
            return null;
        }
    }
