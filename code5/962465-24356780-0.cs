    public class DBTable
    {
        public List<DBField<Object>> FieldName = new List<DBField<Object>>();
        public DBTable (string NameOfTable)
        {
        }
        public void AddField(string Name)
        {
            List<DBField<Object>> TempList = new List<DBField<Object>>();
            FieldName.Add(TempList);
        }
    }
