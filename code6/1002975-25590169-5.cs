    public interface ITableType
    {
        bool Match(string type);
        void Handle(JToken jsonTable);
    }
    
    public AbcTableHandler: ITableType
    {
        public bool Match(string type)
        {
            return type == "abc";
        }
        
        public void Handle(JToken jsonTable)
        {
            var abcTable = jsonTable.ToObject<abcTable>();
            // other code
        }
    }
