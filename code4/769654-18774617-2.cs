    public class DataTableFactory
    {
        public DataTable CreateStringTable()
        {
            var sql = "SELECT * FROM FooBar";
            DataTable dataTable = new DataTable();
            return Database.DefaultDatabase.GetDataTable(sql);
        }
        public DataTable CreateSomeOtherTable()
        {
           //etc etc
        }
    }
