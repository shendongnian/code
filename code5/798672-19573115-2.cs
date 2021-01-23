    using System;
    using System.Reflection;
    using System.IO;
    using SDK;
    
    namespace AppDomains
    {
    	class MainClass
    	{
    	    public static void Main(string[] args)
    	    {
    	        var domain = AppDomain.CreateDomain("Plugin domain"); // Domain for plugins
                domain.Load(typeof(IPlugin).Assembly.FullName); // Load assembly containing plugin interface to domain 
    
    	        var currentPath = Directory.GetCurrentDirectory();
    	        var pluginPath = Path.Combine(currentPath, "Plugins");
    	        var pluginFiles = Directory.GetFiles(pluginPath, "*.dll");
    	        foreach (var pluginFile in pluginFiles) // Foreach dll in Plugins directory
    	        {
    	            var asm = Assembly.LoadFrom(pluginFile);
    	            foreach (var exportedType in asm.GetExportedTypes())
    	            {
    	                if (!typeof(IPlugin).IsAssignableFrom(exportedType)) continue; // Check if exportedType implement IPlugin interface
    	                domain.Load(asm.FullName); // If so load this dll into domain
    	                var plugin = (IPlugin)domain.CreateInstanceAndUnwrap(asm.FullName, exportedType.FullName); // Create plugin instance
    	                plugin.SomeMethod(); // Call plugins methods
    	            }
    	        }
    	        Console.ReadLine();
    	    }
        }
    }
