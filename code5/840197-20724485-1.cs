    public Dictionary<string, string> ExceptionLibrary
    {
        get {
            if (exceptionlibrary == null) {
                exceptionlibrary = new Dictionary<string, string>() {
                    {"10000", "Invalid user input."},
                    {"10001", "Phone number is already registered."},
                };
            }
            return exceptionlibrary;
        }
    }
