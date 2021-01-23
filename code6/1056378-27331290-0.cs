        using System;
        using System.IO;
        using System.Linq;
        using System.Reflection;
        using System.Windows;
        namespace ChildDomainLoader
        {
            public class Runner : MarshalByRefObject
            {
                public static AppDomain RunInOtherDomain(string assemblyPath)
                {
                    var ownType = typeof (Runner);
                    string ownAssemblyName = ownType.Assembly.FullName;
                    // Create a new AppDomain and load our assembly in there.
                    var childDomain = AppDomain.CreateDomain(Guid.NewGuid().ToString());
                    childDomain.Load(ownAssemblyName);
                    // Call Run() in other AppDomain.
                    var runner = (Runner) childDomain.CreateInstanceAndUnwrap(ownAssemblyName, ownType.FullName);
                    runner.Run(assemblyPath);
                    return childDomain;
                }
                public void Run(string assemblyPath)
                {
                    // We load the assembly as byte array.
                    var otherAssemblyBytes = File.ReadAllBytes(assemblyPath);
                    var assembly = AppDomain.CurrentDomain.Load(otherAssemblyBytes);
                    AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
                    {
                        throw new NotImplementedException("Probably need to do some work here if you depend on other assemblies.");
                    };
                    // Set the assembly as ResourceAssembly, as WPF will be confused otherwise.
                    Application.ResourceAssembly = assembly;
                    // Search for the App class.
                    var app = assembly
                        .GetExportedTypes()
                        .Single(t => typeof(Application).IsAssignableFrom(t));
                    // Invoke its Main method.
                    MethodInfo main = app.GetMethod("Main", BindingFlags.Static | BindingFlags.Public);
                    main.Invoke(null, null);
                }
            }
        }
