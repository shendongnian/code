    static System.Reflection.PropertyInfo GetProperty(Type type, string propertyPath)
    {
        System.Reflection.PropertyInfo result = null;
        string[] pathSteps = propertyPath.Split('/');
        Type currentType = type;
        for (int i = 0; i < pathSteps.Length; ++i)
        {
            string currentPathStep = pathSteps[i];
            result = currentType.GetProperty(currentPathStep);
            if (result.PropertyType.IsArray)
            {
                currentType = result.PropertyType.GetElementType();
            }
            else
            {
                currentType = result.PropertyType;
            }
        }
        return result;
    }
