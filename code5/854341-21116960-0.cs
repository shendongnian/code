    System.IO.File.WriteAllLines(myFileName,
                    System.Reflection.Assembly.LoadFile(myDllPath)
                        .GetType(className)
                        .GetMethods()
                        .Select(m => m.Name)
                        .ToArray());
