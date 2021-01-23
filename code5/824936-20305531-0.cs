    void SetPropertyValue(object obj, string propertyPath, object value)
    {
        System.Reflection.PropertyInfo currentProperty = null;
        string[] pathSteps = propertyPath.Split('/');
        object currentObj = obj;
        for (int i = 0; i < pathSteps.Length; ++i)
        {
            Type currentType = currentObj.GetType();
            string currentPathStep = pathSteps[i];
            var currentPathStepMatches = Regex.Match(currentPathStep, @"(\w+)(?:\[(\d+)\])?");
            currentProperty = currentType.GetProperty(currentPathStepMatches.Groups[1].Value);
            int arrayIndex = currentProperty.PropertyType.IsArray ? int.Parse(currentPathStepMatches.Groups[2].Value) : -1;
            if (i == pathSteps.Length - 1)
            {
                currentProperty.SetValue(currentObj, value, arrayIndex > -1 ? new object[] { arrayIndex } : null);
            }
            else
            {
                if (currentProperty.PropertyType.IsArray)
                {
                    currentObj = (currentProperty.GetValue(currentObj) as Array).GetValue(arrayIndex);
                }
                else
                {
                    currentObj = currentProperty.GetValue(currentObj);
                }
            }
        }
    }
