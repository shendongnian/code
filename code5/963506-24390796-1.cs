    public string ReturnFormattedString(string input, iSomeClass myInjectedClass) {
        //If using version 1 of library
        return libx.myInjectedClass.FormatString(input);
        //If using version 1 of library
    
        //If using version 2 of library
        return libx.myInjectedClass.FormatString(intput); 
        //Note: libx.SomeNewClass is not available in version 1
        //If using version 2 of library
    }
