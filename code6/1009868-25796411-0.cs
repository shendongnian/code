    private static void BindClassesToInterfacesByConvention(string classesEndingWith
        , string interfacesEndingwith) {
        Contract.Requires<ArgumentNullException>(classesEndingWith != null
            , "classesEndingWith");
    
        Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(classesEndingWith)
            , "classesEndingWith");
    
        Contract.Requires<ArgumentNullException>(interfacesEndingWith != null
            , "interfacesEndingWith");
    
        Contract.Requires<ArgumentException>(!string.IsNullOrWhiteSpace(interfacesEndingWith)
            , "interfacesEndingWith");
    
        ...
    }
