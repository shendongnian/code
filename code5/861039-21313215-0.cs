    using System;
    using System.IO;
    using System.Management;
    
    namespace GetHardwareIds
    {
    	internal class Program
    	{
    		private static void Main(string[] args)
    		{
    			using (StreamWriter writer = new StreamWriter(@"C:\HardwareInfo.txt"))
    			{
    				using
    				(
    					ManagementObjectSearcher searcher =
    					// Where __Superclass Is Null: selects only top-level classes.
    					// remove it if you need a list of all classes
    					// new ManagementObjectSearcher("Select * From meta_class Where __Superclass Is Null")
    					// this query only select the processor info. for more options uncomment top line
    						new ManagementObjectSearcher("Select * From meta_class Where __Class = 'Win32_Processor'")
    				)
    				{
    					foreach (ManagementObject managementObject in searcher.Get())
    					{
    						Console.WriteLine(managementObject.Path.ClassName);
    						writer.WriteLine(managementObject.Path.ClassName);
    						GetManagementClassProperties(managementObject.Path.ClassName, writer);
    						managementObject.Dispose();
    					}
    				}
    			}
    		}
    
    		public static void GetManagementClassProperties(string path, StreamWriter writer)
    		{
    			using (ManagementClass managementClass = new ManagementClass(path))
    			{
    				foreach (ManagementObject instance in managementClass.GetInstances())
    				{
    					foreach (PropertyData property in instance.Properties)
    					{
    						Console.WriteLine("  {0} = {1}", property.Name, property.Value);
    						writer.WriteLine("  {0} = {1}", property.Name, property.Value);
    					}
    
    					instance.Dispose();
    				}
    			}
    		}
    	}
    }
