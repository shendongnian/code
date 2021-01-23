    //by specifying a messageName, you can do overloading with webmethods
    [WebMethod (MessageName = "listOfStudentsDefault")]  
    [ScriptMethod(UseHttpGet=true)]
    public string listOfStudents(int class, string appLang)
    {
        // code here...
    }
    [WebMethod (MessageName = "listOfStudents")]  
    [ScriptMethod(UseHttpGet=true)]
    public string listOfStudents(int class)
    {
        return listOfStudents(class, "ar");
    }
