	    public interface ITransactionBuilder
	    {
	        IRowBuilder UpdateTable(string tableName);
	    }
	    public interface IRowBuilder
	    {
	        IColumnBuilder Row(long rowid);
	    }
	    public interface INextColumnBuilder : IColumnBuilder, IRowBuilder, ITransactionBuilder, ITransactionHolder { }
	    public interface IColumnBuilder
	    {
	        INextColumnBuilder Column(string columnName, Object columnValue);
	        //I still want to write something like this here!!! But currently we may only to comment it :(
	        //<IColumnBuilder, IRowBuilder, ITransactionBuilder, ITransactionHolder> Column(string columnName, Object columnValue)
	    }
	    public interface ITransactionHolder
	    {
	        ITransaction GetTransaction();
	    }
	    public interface ITransaction
	    {
	        //Execute func declaration
	    }
