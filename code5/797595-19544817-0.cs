    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    
    
    using System.DirectoryServices;
    
    namespace IIS_1
    {
        class Program
        {
            static void Main(string[] args)
            {
                DirectoryEntry root = new DirectoryEntry("IIS://localhost/W3SVC");
                string VirDirSchemaName = "IIsWebVirtualDir";
    
                foreach (DirectoryEntry e in root.Children)
                {
                    
                    foreach (DirectoryEntry folderRoot in e.Children)
                    {
                        foreach (DirectoryEntry virtualDirectory in folderRoot.Children)
                        {
                            if (VirDirSchemaName == virtualDirectory.SchemaClassName)
                            {
                                Console.WriteLine(String.Format("\t\t{0} \t\t{1}", virtualDirectory.Name, virtualDirectory.Properties["Path"].Value));
                            }
                        }
                    }
                }
            }
        }
    }
