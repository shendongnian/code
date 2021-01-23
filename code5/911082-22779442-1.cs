    public class UseNetDataContractSerializerAttribute : Attribute, IOperationBehavior, IContractBehavior
    {
        void IOperationBehavior.ApplyClientBehavior(OperationDescription description, ClientOperation proxy)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }
        void IOperationBehavior.ApplyDispatchBehavior(OperationDescription description, DispatchOperation dispatch)
        {
            ReplaceDataContractSerializerOperationBehavior(description);
        }
        void IOperationBehavior.Validate(OperationDescription description)
        {
        }
        void IOperationBehavior.AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }
        private static void ReplaceDataContractSerializerOperationBehavior(OperationDescription description)
        {
            var behavior = description.Behaviors.Find<DataContractSerializerOperationBehavior>();
            if (behavior != null)
            {
                description.Behaviors.Remove(behavior);
                description.Behaviors.Add(new NetDataContractSerializerOperationBehavior(description));
            }
        }
        void IContractBehavior.ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            foreach (var operation in contractDescription.Operations)
            {
                ReplaceDataContractSerializerOperationBehavior(operation);
            }
        }
        void IContractBehavior.ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (var operation in contractDescription.Operations)
            {
                ReplaceDataContractSerializerOperationBehavior(operation);
            }
        }
        void IContractBehavior.Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
        }
        void IContractBehavior.AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }
    }
    public class NetDataContractSerializerOperationBehavior : DataContractSerializerOperationBehavior
    {
        public NetDataContractSerializerOperationBehavior(OperationDescription operation)
            : base(operation)
        {
        }
        public NetDataContractSerializerOperationBehavior(OperationDescription operation, DataContractFormatAttribute dataContractFormatAttribute)
            : base(operation, dataContractFormatAttribute)
        {
        }
        public override XmlObjectSerializer CreateSerializer(Type type, string name, string ns, IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }
        public override XmlObjectSerializer CreateSerializer(Type type, XmlDictionaryString name, XmlDictionaryString ns, IList<Type> knownTypes)
        {
            return new NetDataContractSerializer(name, ns);
        }
    }
