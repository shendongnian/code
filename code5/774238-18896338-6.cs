     abstract class foo
        {
             public string myId {get;set;}
             public string mystring {get;set;}
             public foo3 my3rdFoo {get;set}
        }
        
        class foo2 : foo
        {
             public foo3 myFavoriteFoo {get;set;}
    
             public foo2(string myName)
             {
                 foo3 = new foo3();
                 foo3.myName = myName;
    
             }
    
        }
        
        class foo3
        {
             public string myName{get;set}         
        }
