    public static class BuildVariables
    {
        public static List<string> DefinedVariables = new List<string>()
        {
            #if CUSTOMER1_ABC_EXTENSION
            "CUSTOMER1_ABC_EXTENSION",
            #endif
            #if CUSTOMER2_XYZ_EXTENSION
            "CUSTOMER2_XYZ_EXTENSION",
            #endif
        };
    }
