    Assembly assembly = Assembly.Load("AssemblyName");
            Type objectType = assembly.GetType("TypeName");
            object dynamicObject = Activator.CreateInstance(objectType);
            
            objectType.GetField("VariableName").SetValue(dynamicObject, "FieldValue");
