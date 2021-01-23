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
                        var obj = plugin.GetSDKType();
                        obj.SDKDelegate();
                        var dict = obj.GetDictionary();
                        foreach (var pair in dict)
                        {
                            Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
                        }
                        obj.SDKEvent += obj_SDKEvent;
                        obj.RiseSDKEvent(string.Format("Argument from domain {0}", AppDomain.CurrentDomain.FriendlyName));
    	            }
    	        }
    	        Console.ReadLine();
    	    }
    
            static void obj_SDKEvent(object sender, StringEventArgs e)
            {
                Console.WriteLine("Received event in {0}", AppDomain.CurrentDomain.FriendlyName);
                Console.WriteLine(e.Message);
            }
        }
    }
