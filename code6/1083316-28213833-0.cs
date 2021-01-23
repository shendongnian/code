    public interface IVisitor
    {
    	void visit(Row v);
    	void visit(Table v);
    }
    
    public interface IVisitable
    {
    	void accept(IVisitor visitor);
    }
    
    public class Table : IVisitable
    {
        public List<Row> rows;
        public void accept(IVisitor visitor)
        {
            foreach(Row row in rows)
                row.accept(visitor);
            visitor.visit(this);
        }
    }
    
    public class Row : IVisitable
    {
        public int number;
        public void accept(IVisitor visitor)
        {
            visitor.visit(this);
        }
    }
