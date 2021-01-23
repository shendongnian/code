    public class Table 
    {
       public int ID {get;set;}
       public int RowID{get;set;}
       public int ColumnID{get;set;}
       public string Cellvalue { get; set; }
    
       public Table(int id, int rowid, int columnid, string cellvalue)
       {
    	   ID = id;
    	   RowID = rowid;
    	   ColumnID = columnid;
    	   Cellvalue = cellvalue;
       }
    }
    
    public class TableRow
    {
    	public List<string> Values { get; set; }
    
    	public TableRow (IGrouping<int,Table> group)
    	{
    		Values = group.OrderBy(y => y.ColumnID)
    					  .Select(y => y.Cellvalue)
    					  .ToList();
    	}
    
    	public override bool Equals(object obj)
    	{
    		TableRow row = obj as TableRow;
    		if (row != null)
    		{
    			if (row.Values != null && row.Values.Count == Values.Count)
    			{
    				for (int i = 0; i < Values.Count; i++)
    				{
    					if (Values[i] != row.Values[i])
    					{
    						return false;
    					}
    				}
    
    				return true;
    			}
    		}
    
    		return base.Equals(obj);
    	}
    }
    
    
    List<Table> table = new List<Table>() { 
    	new Table(1, 1, 1, "A"),
    	new Table(2, 1, 2, "B"),
    	new Table(3, 2, 1, "C"),
    	new Table(4, 2, 2, "D")
    };
    
    List<TableRow> rowsTable1 = table.GroupBy(x => x.RowID)
    								 .Select(x => new TableRow(x))
    								 .ToList();
    
    List<Table> table2 = new List<Table>() { 
    	new Table(1, 1, 1, "X"),
    	new Table(2, 1, 2, "Y"),
    	new Table(3, 6, 1, "A"),
    	new Table(4, 6, 2, "C"),
    	new Table(5, 8, 1, "A"),
    	new Table(6, 8, 2, "B"),
    	new Table(7, 9, 1, "A"),
    	new Table(8, 9, 2, "B")
    };
    
    List<Table> table3 = table2.GroupBy(x => x.RowID)
    						   .Where(x => rowsTable1.Exists(y=> y.Equals(new TableRow(x))))
    						   .SelectMany(x =>  (IEnumerable<Table>)x)
    						   .ToList();
