    using System;
    using System.Diagnostics;
    using System.Reflection;
    
    
    namespace NDepend.PowerTools {
       internal static class AssemblyResolverHelper {
          internal static Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args) {
             var assemblyName = new AssemblyName(args.Name);
             Debug.Assert(assemblyName != null);
             var assemblyNameString = assemblyName.Name;
             Debug.Assert(assemblyNameString != null);
    
             // Special treatment for NDepend.API and NDepend.Core because they are defined in $NDependInstallDir$\Lib
             if (assemblyNameString != "NDepend.API" &&
                 assemblyNameString != "NDepend.Core") {
                return null;
             }
             string binPath =
                  System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                  System.IO.Path.DirectorySeparatorChar +
                  "Lib" +
                  System.IO.Path.DirectorySeparatorChar;
    
             const string extension = ".dll";
    
             var assembly = Assembly.LoadFrom(binPath + assemblyNameString + extension);
             return assembly;
          }
       }
    }
