    public class A 
    {
        public DataTable Table { get; set; }
    }
    
    public class B 
    {
        public DataTable Table { get; set; }
    }
    
    DataTable someTable = new DataTable();
    
    // Both class instances share the same DataTable
    // because you set the same object to both
    // class properties
    A someA = new A();
    someA.Table = someTable;
    
    B someB = new B();
    someB.Table = someTable;
