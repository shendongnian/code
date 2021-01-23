    class Table1
    {
    	public int IdA { get; set; }
    	public int IdB { get; set; }
    	public string Table1StrValue { get; set; }
    }
    
    class Table2
    {
    	public int IdA { get; set; }
    	public string Table2StrValue { get; set; }
    }
        
    var table1List = new List<Table1>()
    	{
    		new Table1 {IdA = 1, IdB = 3, Table1StrValue = "sample"},
    		new Table1 {IdA = 2, IdB = 1, Table1StrValue = "test"},
    		new Table1 {IdA = 3, IdB = 2, Table1StrValue = "string"},
    	};
    var table2List = new List<Table2>()
    	{
    		new Table2 {IdA = 1, Table2StrValue = "my Name"},
    		new Table2 {IdA = 2, Table2StrValue = "his Name"},
    		new Table2 {IdA = 3, Table2StrValue = "her Name"},
    	};
    
    var result = from table2 in table2List
    		join table1 in table1List on table2.IdA equals table1.IdA
    		orderby table2.Table2StrValue
    		select new {table2.IdA, table2.Table2StrValue, table1.Table1StrValue};
