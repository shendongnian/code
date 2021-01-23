    class GetRowsWrapper
    {
    	X _instance;
    
    	public Something(X instance)
    	{
    		_instance = instance;
    	}
    	
    	public IEnumerable<QvxDataRow> getRows()
    	{
    		// do something with _instance
            yield return yourstuff;
    	}
    }
    public void getTables() {
        foreach(X currentTable in mapper.getTables()) {
            var x = new X {
            TableName = currentTable.getName(),
            Fields = Fields.ToArray()
            });
            // lambda to wrap getRows into a GetRowsHandler
            x.GetRows = () => new GetRowsWrapper(x).getRows();
            MTables.Add(x);
        }
    }
