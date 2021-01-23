    public class DataInterop<T>: ITableAdapter where T: ITableAdapter
    {
        private ITableAdapter tableAdapter;
        public DataInterop(T tableAdapter)
        {
            this.tableAdapter = tableAdapter;
        }
    }
