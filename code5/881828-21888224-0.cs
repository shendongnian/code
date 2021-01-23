    [ServiceContract(Namespace = "http://example.com/Example/v1", ProtectionLevel = ProtectionLevel.EncryptAndSign)]
    public interface IClientsUploader
    {
        [OperationContract()]
        Task<Results> UploadClientsAsync(Database database, Client[] clients);
    }
