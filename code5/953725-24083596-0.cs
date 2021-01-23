    [OperationContract, FaultContract(typeof(ServiceError))]
    [WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped]
    Entity SaveEntity(XElement entitySerialized)
    {
        var entity = Deserialize(entitySerialized);
        var realService = new MyServiceClient();
        return realService.SaveEntity(entity);
    }
