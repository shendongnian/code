    public void getTables() {
        foreach(X currentTable in mapper.getTables()) {
            MTables.Add(new X {
                TableName = currentTable.getName(),
                GetRows = getRows(currentTable.getName()), 
                Fields = Fields.ToArray()
            });
        }
    }
    // this method now returns another method that matches GetRowsHandler 
    private GetRowsHandler getRows(string tablename) {         
        // this lambda method uses the tablename parameter
    	return () =>
    	{
    		// something with foreach row in table tablename
    	};
    }
