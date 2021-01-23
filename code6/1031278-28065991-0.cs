     private void TestAssemblies()
        {
            var allAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly item in allAssemblies)
            {
                PrintAssembly(item);
            }
        }
        private void PrintAssembly(Assembly assembly)
        {
            foreach (var item in assembly.GetReferencedAssemblies())
            {
                if (item.FullName.Contains("System.Web.Mvc"))
                {
                    Debug.WriteLine(item);
                    Debug.WriteLine("Parent: " + assembly.FullName);
                    Debug.WriteLine("------------------------------------------------------------");
                }
            }
        }
