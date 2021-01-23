    List<string> allEnums = new List<string>();
    var allTypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(assembly => assembly.GetTypes());
    foreach (Type type in allTypes)
    {
        if (type.Namespace == "MyCompany.SystemLib" && type.IsEnum)
        {
            string enumLine = type.Name + ",";
            foreach (var enumValue in Enum.GetValues(type))
            {
                enumLine += enumValue + "=" + ((int)enumValue).ToString() + ",";
            }
            allEnums.Add(enumLine);
        }
    }
