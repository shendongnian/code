    public static void DoSomething(this Base myObj, Object dependency)
    {       
        if(myObj.IsSubclassOf(Base))
        {
          // A derived class, call appropriate extension method.  
          DoSomething(myObj as dynamic, dependency);
        }
        else
        {
            // The object is Base class so handle it.
        }
    } 
