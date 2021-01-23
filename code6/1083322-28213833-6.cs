    public interface IVisitor
    {
    	void visit(Row v);
    	void visit(Table v);
    	bool keepgoing { get; }
    }
    public class Table : IVisitable
    {
        public List<Row> rows;
        public void accept(IVisitor visitor)
        {
            foreach(Row row in rows)
                if (visitor.keepgoing) row.accept(visitor);
    			else break;
            visitor.visit(this);
        }
    }
    public class FirstTwoRowVisitor : IVisitor
    {
    	int _numOfRows = 0;
    
    	public bool keepgoing { get { return _numOfRows < 2; } }
    
    	public void visit(Row r)	
    	{ 
    		if (!keepgoing)
    			return;
    		Console.WriteLine("Visited Row #{0}", r.number);
    		_numOfRows++;
    	}
    	
    	public void visit(Table t)	
    	{
    		Console.WriteLine("Table has {0} Rows total", t.rows.Count);
    	}
    }
