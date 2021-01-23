        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs e)
        {
            try
            {
                if (!e.Name.ToLower().StartsWith("system.threading.tasks"))
                    return null;
                AddoDebug.Instance.WriteLine("Assembly_Resolve");
                var assemblyDetail = e.Name.Split(',');
                var assemblyBasePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var assembly = Assembly.LoadFrom(assemblyBasePath + @"\" + assemblyDetail[0] + ".dll");
                return assembly;
            }
            catch (Exception ex)
            {
                AddoDebug.Instance.WriteLine("An exception occurred: " + ex, ADDOTraceStatus.Exception);
                return null;
            }
        }
