    namespace Classes
    {
        class MyMethods
        {              
            public void DoSomeStuff(MyVariableClass myVarClass, string myString1, string myString2)
            {
               myVarClass.MyVariable = (!string.IsNullOrEmpty(myString2)
                   ? myString2 : "String 2 has nothing!");
            }
        }
    }
