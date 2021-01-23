        [DataContract]
    public class SerializableTableEntity : ITableEntity
    {
        private CustomEntity tableEntity;
    
        public string ETag { 
        {
            get
            {
                return tableEntity.ETag;
            }
            set
            {
                tableEntity.Etag = value;
            }
        }
    
        public string PartitionKey
        {
            get
            {
                return tableEntity.PartitionKey;
            }
            set
            {
                tableEntity.PartitionKey = value;
            }
        }
    
        public string RowKey
        {
            get
            {
                return tableEntity.RowKey;
            }
            set
            {
                tableEntity.RowKey = value;
            }
        }
    
        public DateTimeOffset Timestamp
        {
            get
            {
                return tableEntity.Timestamp;
            }
            set
            {
                tableEntity.Timestamp = value;
            }
        }
    
        public string PropertyOne
        {
            get
            {
                return tableEntity.PropertyOne;
            }
            set
            {
                tableEntity.PropertyOne = value;
            }
        }
    
    
        public SerializableTableEntity()
        {
            tableEntity = new CustomEntity();
        }
    
        public void ReadEntity(IDictionary<string, EntityProperty> properties, Microsoft.WindowsAzure.Storage.OperationContext operationContext)
        {
            tableEntity.ReadEntity(properties, operationContext);
        }
    
        public IDictionary<string, EntityProperty> WriteEntity(Microsoft.WindowsAzure.Storage.OperationContext operationContext)
        {
            return tableEntity.WriteEntity(operationContext);
        }
    }
    
    public class CustomEntity : TableEntity
    {
        public string PropertyOne { get; set; }
    }
