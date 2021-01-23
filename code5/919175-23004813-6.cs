    [ServiceContract(ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IService
    {
        [OperationContract(IsOneWay = false)]
        string Register();
    }
