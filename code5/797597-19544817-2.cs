    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    // to add it from %windir%\System32\InetSrv\Microsoft.Web.Administration.dll
    using Microsoft.Web.Administration;
    
    namespace IIS_7
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (ServerManager serverManager = new ServerManager())
                {
                    foreach (var site in serverManager.Sites)
                    {
    
                        Console.WriteLine(String.Format("Site: {0}", site.Name));
    
                        foreach (var app in site.Applications)
                        {
                            var virtualRoot = app.VirtualDirectories.Where(v => v.Path == "/").Single();
    
                            Console.WriteLine(String.Format("\t\t{0} \t\t{1}", app.Path, virtualRoot.PhysicalPath));
                        }
                    }
                }
            }
        }
    }
