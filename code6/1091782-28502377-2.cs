    [ServiceContract]
    public interface ICredentialReplication
    {
        /// <summary>
        /// Updates the store database with credential data
        /// </summary>
        /// <param name="credentials">the credential data to update</param>
        [OperationContract]
        void ReplicateData(CredentialDataList credentials);
    }
