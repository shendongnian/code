    System.Reflection.Assembly Resolver(object sender, System.ResolveEventArgs args)
    {
         string assembly_dll = new AssemblyName(args.Name).Name + ".dll";
         string assembly_directory = "Parent directory of the C++ dlls";
    
         Assembly assembly = null;
         if(Environment.Is64BitProcess)
         {
                assembly = Assembly.LoadFile(assembly_directory + @"\x64\" + assembly_dll);
         }
         else
         {
                assembly = Assembly.LoadFile(assembly_directory + @"\x86\" + assembly_dll);
         }
         return assembly;
    }
