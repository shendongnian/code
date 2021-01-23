    public static class Throw
    {
        public static void IfNull<T>(T parameter, string parameterName) where T : class
        {
            if (parameter == null) 
                throw ArgumentNullException(string.Format("Parameter {0} is null", parameterName));
        }
    }
