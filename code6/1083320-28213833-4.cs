    public class FirstTwoRowVisitor : IVisitor
    {
    	int _numOfRows = 0;
    
    	public void visit(Row r)	
    	{ 
    		if (_numOfRows == 2)
    			return;
    		Console.WriteLine("Visited Row #{0}", r.number);
    		_numOfRows++;
    	}
    	
    	public void visit(Table t)	
    	{
    		Console.WriteLine("Table has {0} Rows total", t.rows.Count);
    	}
    }
