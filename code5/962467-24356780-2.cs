    public class DBTable
    {
        public List<DBField<Object>> FieldName = new List<DBField<Object>>();
        public DBTable (string NameOfTable)
        {
        }
        public void AddField<FieldType>(string Name)
        {
            DBField<FieldType> field = new DBField<FieldType>(Name);
            FieldName.Add(field);
        }
    }
