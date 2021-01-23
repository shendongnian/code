	    class TransactionBuilder : INextColumnBuilder
	    //I want to write this: class TransactionBuilder : IColumnBuilder, IRowBuilder, ITransactionBuilder, ITransactionHolder
	    //But then we will fail on "return this;" from Column() func, because class TransactionBuilder not inherits from INextColumnBuilder, and again interface joining should solve it...
	    {
	        public virtual IRowBuilder UpdateTable(string tableName)
	        {
	            m_currentTable = new TableHolder(tableName);
	            m_commands.Add(new UpdateCommand(m_currentTable));
	            return this;
	        }
	        public virtual IColumnBuilder Row(long rowid)
	        {
	            m_currentRow = new RowHolder(rowid);
	            m_currentTable.AddRow(m_currentRow);
	            return this;
	        }
	        public virtual INextColumnBuilder Column(string columnName, Object columnValue)
	        //And the dream is: <IColumnBuilder, IRowBuilder, ITransactionBuilder, ITransactionHolder> Column(string columnName, Object columnValue)
	        {
	            m_currentRow.AddColumn(columnName, columnValue);
	            return this;
	        }
	        public virtual ITransaction GetTransaction()
	        {
	            return new Transaction(m_commands);
	        }
	        private ICollection<ICommand> m_commands = new LinkedList<ICommand>();
	        private TableHolder m_currentTable;
	        private RowHolder m_currentRow;
	    }
