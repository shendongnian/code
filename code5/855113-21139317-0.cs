    public class MyObjRecordSet
    {
        private readonly IDataReader InnerDataReader;
        private readonly int OrdinalId;
        private readonly int OrdinalCreated;
        public MyObjRecordSet(IDataReader dataReader)
        {
            this.InnerDataReader = dataReader;
            this.OrdinalId = dataReader.GetOrdinal("Id");
            this.OrdinalCreated = dataReader.GetOrdinal("Created");
        }
        public int Id
        {
            get
            {
                return this.InnerDataReader.GetInt32(this.OrdinalId);
            }
        }
        public DateTime Created
        {
            get
            {
                return this.InnerDataReader.GetDateTime(this.OrdinalCreated);
            }
        }
        public MyObj ToObject()
        {
            return new MyObj
            {
                Id = this.Id,
                Created = this.Created
            };
        }
        public static IEnumerable<MyObj> ReadAll(IDataReader dataReader)
        {
            MyObjRecordSet recordSet = new MyObjRecordSet(dataReader);
            while (dataReader.Read())
            {
                yield return recordSet.ToObject();
            }
        }
    }
