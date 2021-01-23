        public static object CallThisMethod(string className, string methodName, object[] parms)
        {
            Type type = Type.GetType(className);
            MethodInfo theMethod = type.GetMethod(methodName);
            object classInstance = Activator.CreateInstance(type);
            return theMethod.Invoke(classInstance, parms);
        }
