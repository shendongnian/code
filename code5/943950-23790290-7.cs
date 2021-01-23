    var mi = ExtensionMethodsHelper.GetExtensionMethodOrNull(typeof(string), "MyExtensionMethod");
            if (mi != null)
            {
                Console.WriteLine(mi.Invoke(null, new object[] { "hello world" }));
            }
            else
            {
                Console.WriteLine("did't find extension method with name " + "MyExtensionMethod");
            }
