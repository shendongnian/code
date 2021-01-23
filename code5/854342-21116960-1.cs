     System.IO.File.WriteAllLines(myFileName,
                    System.Reflection.Assembly.LoadFile(myDllPath)
                        .GetTypes()                    
                        .SelectMany(t => t.GetMethods())
    					.Select(m => m.Name)
                        .ToArray());
