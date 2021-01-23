    namespace Classes
    {
        class MyMethods
        {
            public MyVariableClass MyVarClass {get; private set;}
    
    
            public void DoSomeStuff(string myString1, string myString2)
            {
               if(MyVarClass == null)
               {
                  MyVarClass = new MyVariableClass();
               }
    
               MyVarClass.MyVariable = (!string.IsNullOrEmpty(myString2)
                   ? myString2 : "String 2 has nothing!");
            }
        }
    }
