    public class FirstRepo
    { 
       DbContext _ctx;
       public FirstRepo( DbContext ctx )
       { 
           this._ctx = ctx;
       }
    }
    public class AnotherRepo
    { 
       DbContext _ctx;
       public AnotherRepo( DbContext ctx )
       { 
           this._ctx = ctx;
       }
    }
