    [System.ServiceModel.ServiceContractAttribute(Namespace="http://example.com/Example/v1", ConfigurationName="Example.IClientsUploader")]
    public interface IClientsUploader
    {
        [System.ServiceModel.OperationContractAttribute(Action="http://example.com/Example/v1/IClientsUploader/UploadClients", ReplyAction="http://example.com/Example/v1/IClientUploader/UploadClientsResponse")]
        Example.DataStructures.Results UploadClients(Example.DataStructures.Database database, System.Collections.Generic.IEnumerable<Example.DataStructures.Client> clients);
    }
