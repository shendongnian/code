    abstract class foo
    {
         public foo() { this.my3rdFoo = new foo3(); }
         public string myId {get;set;}
         public string mystring {get;set;}
         public foo3 my3rdFoo {get;set}
    }
    
    class foo2 : foo
    {
         public string myFavoriteFoo {get;set;}
    }
    
    class foo3
    {
         public string myName{get;set}         
    }
