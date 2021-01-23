        static class DoWorkFactory
        {
            internal static IDoWork Build()
            {
                // Load the version-specific assembly
    
                // - Via reflection (see http://stackoverflow.com/a/465509/904178)
                // - Or via MEF
                return ...;
            }
        }
