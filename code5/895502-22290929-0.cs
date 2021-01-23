    Object[] mthdInps = new Object[2]; 
    mthdInps[0] = mScope; 
    string paramSrvrName = srvrName; 
    mthdInps[1] = paramSrvrName; 
    Assembly runTimeDLL = Assembly.LoadFrom("ClassLibrary.dll"); 
    Type runTimeDLLType = runTimeDLL.GetType("ClassLibrary.Class1"); 
    //do not pass parameters if the constructor doesn't have 
    Object compObject = Activator.CreateInstance(runTimeDLLType); 
    Type compClass = compObject.GetType(); 
    MethodInfo mthdInfo = compClass.GetMethod("Method1"); 
    // one parameter of type object array
    object[] parameters = new object[] { mthdInps };
    string mthdResult = (string)mthdInfo.Invoke(compObject, parameters );
