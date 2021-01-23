    public static class ColumnListExtensions
    {
    	public static ToColumnList(this IEnumerable<Column> collection)
    	{
    		return new ColumnList(collection);
    	}	
    }
    var cols = othercolumnlist.Select(c => new Column { Name = c.Name })
               .ToColumnList();
