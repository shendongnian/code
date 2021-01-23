            List<IBaseInterface> list = new List<IBaseInterface>();
            var assembly = System.Reflection.Assembly.LoadFrom("ClassLibrary.dll");
            if (assembly != null)
            {
                var ObjTypes = assembly.GetTypes();
                foreach (var objType in ObjTypes)
                {
                    try
                    {
                        var type = Activator.CreateInstance(objType);
                        if (type is IBaseInterface)
                        {
                            list.Add((IBaseInterface)type);
                        }
                    }
                    catch (Exception ex)
                    {
                        int a = 0;
                    }
                }
            }
