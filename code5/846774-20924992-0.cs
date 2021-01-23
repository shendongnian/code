     [ServiceContract]
        public interface IDataForSilverlight
        {
            [OperationContract]
            List<TableName> GetList();
        }
