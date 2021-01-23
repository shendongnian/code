    public void SomeMethod()
    {
        var container = new 
        {
            user = userWS.GetUsers(),
            documents = documentWS.GetDocuments()
        }
    
        // returns: "user.username.value"
        string usernameProperty = GetMapperValueById ( "username" );
    
        var value = GetPropertyValue(container, usernameProperty);
    }
    static GetPropertyValue(object obj, string propertyPath)
    {
        System.Reflection.PropertyInfo result = null;
        string[] pathSteps = propertyPath.Split('.');
        object currentObj = obj;
        for (int i = 0; i < pathSteps.Length; ++i)
        {
            Type currentType = currentObj.GetType();
            string currentPathStep = pathSteps[i];
            var currentPathStepMatches = Regex.Match(currentPathStep, @"(\w+)(?:\[(\d+)\])?");
            result = currentType.GetProperty(currentPathStepMatches.Groups[1].Value);
            if (result.PropertyType.IsArray)
            {
                int index = int.Parse(currentPathStepMatches.Groups[2].Value);
                currentObj = (result.GetValue(currentObj) as Array).GetValue(index);
            }
            else
            {
                currentObj = result.GetValue(currentObj);
            }
    
        }
        return currentObj;
    }
