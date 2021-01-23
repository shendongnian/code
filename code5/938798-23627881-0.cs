        public class RecordData
    {
        public Guid className { get; set; }
        public DataFields<AccountItem> dataFields { get; set; }  //or  public DataFields<RankItem> dataFields { get; set; }
    }
    public class DataFields<T>
    {
        public List<T> Items { get; set; }
        public DataFields()
        {
            Items = new List<T>();
        }
    }   
