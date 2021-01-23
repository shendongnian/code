    public class StringTable
    {
        private DataTable dataTable;
        public StringTable()
        {
            var sql = "SELECT * FROM FooBar";
            // I know that that's not a legal C# statement but 
            // if it were, I'd want to do the equivalent of the following:
            dataTable = Database.DefaultDatabase.GetDataTable(sql);
        }
    }
