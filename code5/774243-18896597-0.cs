    abstract class foo
    {
         public string myId {get;set;}
         public string mystring {get;set;}
         public foo3 my3rdFoo {get;set}
         public foo()
         {
              this.my3rdFoo = new foo3();
         }
    }
