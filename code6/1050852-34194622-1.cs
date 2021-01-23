    public static void AddServerVariable(this HttpRequest request, string key, string value)
        {
            BindingFlags temp = BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static;
            MethodInfo addStatic = null;
            MethodInfo makeReadOnly = null;
            MethodInfo makeReadWrite = null;
            Type type = request.ServerVariables.GetType();
            MethodInfo[] methods = type.GetMethods(temp);
            foreach (MethodInfo method in methods)
            {
                switch (method.Name)
                {
                    case "MakeReadWrite":
                        makeReadWrite = method;
                        break;
                    case "MakeReadOnly":
                        makeReadOnly = method;
                        break;
                    case "AddStatic":
                        addStatic = method;
                        break;
                }
            }
            makeReadWrite.Invoke(request.ServerVariables, null);
            string[] values = { key, value };
            addStatic.Invoke(request.ServerVariables, values);
            makeReadOnly.Invoke(request.ServerVariables, null);
        }
