	    public interface ICommand 
	    {
	        //Apply func declaration
	    }
	    public class UpdateCommand : ICommand 
	    {
	        public UpdateCommand(TableHolder table) { /* ... */ }
	        //Apply func implementation
	    }
	    public class TableHolder
	    {
	        public TableHolder(string tableName) { /* ... */ }
	        public void AddRow(RowHolder row) { /* ... */ }
	    }
	    public class RowHolder
	    {
	        public RowHolder(long rowid) { /* ... */ }
	        public void AddColumn(string columnName, Object columnValue) { /* ... */ }
	    }
	    public class Transaction : ITransaction
	    {
	        public Transaction(IEnumerable<ICommand> commands) { /* ... */ }
	        //Execute func implementation
	    }
