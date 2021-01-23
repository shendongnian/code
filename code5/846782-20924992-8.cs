     [ServiceContract]
        public interface IServices1
        {
            [OperationContract]
            List<TableName> GetList();
        }
