            var executingAssembly = Assembly.GetExecutingAssembly();
            var resourceNames = executingAssembly.GetManifestResourceNames();
            foreach (var resourceName in resourceNames)
            {
                Console.WriteLine("Resource: " + resourceName);
                Console.WriteLine("Contents:");
                using (var sr = new StreamReader(executingAssembly.GetManifestResourceStream(resourceName)))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
