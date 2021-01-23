    public abstract class TableCollectionComparer<T>
    {
        protected bool Compare(DataRow row, T item);
        
        public bool Compare(DataTable table, ICollection<T> item)
        {
            foreach(DataRow row in table.Rows)
            {
                 ...
                 bool result = Compare(row, item);
            }
        }
    }
