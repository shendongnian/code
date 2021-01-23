    public interface VisitableElement
    {
        void accept (VisitorElement visitor); 
    }
    
    public class SomeClass : VisitableElement
    {
        public void accept(VisitorElement visitor) { }
    }
    
    public interface VisitorElement
    {
    	void visit (VisitableElement visitable);
    }
    
    public interface VisitorElement<T> : VisitorElement where T : VisitableElement
    {
        void visit (T visitable);
    }
    
    class Visitor: VisitorElement<SomeClass>
    {
        public void visit (SomeClass someobject) { }
    	
    	void VisitorElement.visit(VisitableElement visitable) { }
    }
