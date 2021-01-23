    public class ReferencePreservingProxyDataContractSerializerOperationBehavior
        : DataContractSerializerOperationBehavior
    {
        public ReferencePreservingProxyDataContractSerializerOperationBehavior(
          OperationDescription operationDescription)
            : base(operationDescription) { }
        public override XmlObjectSerializer CreateSerializer(
          Type type, string name, string ns, IList<Type> knownTypes)
        {
            return CreateDataContractSerializer(type, name, ns, knownTypes);
        }
        private static XmlObjectSerializer CreateDataContractSerializer(
          Type type, string name, string ns, IList<Type> knownTypes)
        {
            return CreateDataContractSerializer(type, name, ns, knownTypes);
        }
        public override XmlObjectSerializer CreateSerializer(
          Type type, XmlDictionaryString name, XmlDictionaryString ns,
          IList<Type> knownTypes)
        {
            return new DataContractSerializer(type, name, ns, knownTypes,
                0x7FFF /*maxItemsInObjectGraph*/,
                false/*ignoreExtensionDataObject*/,
                true/*preserveObjectReferences*/,
                null/*dataContractSurrogate*/,
                new ProxyDataContractResolver());
        }
    }
    public class ReferencePreservingProxyDataContractFormatAttribute : Attribute, IOperationBehavior
    {
        public void AddBindingParameters(OperationDescription description, BindingParameterCollection parameters)
        {
        }
        public void ApplyClientBehavior(OperationDescription description, System.ServiceModel.Dispatcher.ClientOperation proxy)
        {
            IOperationBehavior innerBehavior = new ReferencePreservingProxyDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyClientBehavior(description, proxy);
        }
        public void ApplyDispatchBehavior(OperationDescription description, System.ServiceModel.Dispatcher.DispatchOperation dispatch)
        {
            IOperationBehavior innerBehavior = new ReferencePreservingProxyDataContractSerializerOperationBehavior(description);
            innerBehavior.ApplyDispatchBehavior(description, dispatch);
        }
        public void Validate(OperationDescription description)
        {
        }
    }
