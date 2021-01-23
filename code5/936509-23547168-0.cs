    [ServiceContract(Namespace = NameSpace.Root)]
        public interface IDirectoryManagementService
        {
            [OperationContract(Name = "createLocalUser")]
            string CreateLocalUser(DataContracts.User localUser, string password);
