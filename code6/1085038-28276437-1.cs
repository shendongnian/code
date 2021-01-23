    static IEnumerable<Type> GetGenericTypeArgument(dynamic inputObject)
        {
            var genType = inputObject.GetType();
            return genType.GetGenericArguments();
        }
