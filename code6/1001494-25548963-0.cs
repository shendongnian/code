    public class A 
    {
        public DataTable Table { get; set; }
    }
    
    public class B 
    {
        public DataTable Table { get; set; }
    }
    
    DataTable someTable = new DataTable();
    
    A someA = new A();
    someA.Table = someTable;
    
    B someB = new B();
    someB.Table = someTable;
