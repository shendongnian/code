    using System;
    using System.Collections.Generic;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Printing;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Controls;
    using System.Windows.Xps.Packaging;
    using System.Runtime.InteropServices;
    using mscoree;
    using System.Diagnostics;
    using System.Threading;                           
    
    namespace ConsoleApplication2
    {
        class AppDomainWorker
        {
            public void DoSomeWork()
            {
                while (true)
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        var hello = "hello world".GetHashCode();
                    }
                    Thread.Sleep(500);
                }
            }
        }
    
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                PerformanceCounter toPopulate = new PerformanceCounter(".Net CLR Loading", "Total Appdomains", "ConsoleApplication2.vshost", true);
    
                Console.WriteLine("App domains listed = {0}", toPopulate.NextValue().ToString());
    
                for (int i = 0; i < 10; i++)
                {
                    AppDomain domain = AppDomain.CreateDomain("App Domain " + i);
                    domain.DoCallBack(() => new Thread(new AppDomainWorker().DoSomeWork).Start());
    
                    Console.WriteLine("App domains listed = {0}", toPopulate.NextValue().ToString());
                }
    
                Console.WriteLine("List all app domains");
                GetAppDomains().ForEach(a => {
                    Console.WriteLine(a.FriendlyName);
                });
    
                Console.WriteLine("running, press any key to stop");
    
                Console.ReadKey();        
            }
    
            public static List<AppDomain> GetAppDomains()
            {
                List<AppDomain> _IList = new List<AppDomain>();
                IntPtr enumHandle = IntPtr.Zero;
                CorRuntimeHostClass host = new mscoree.CorRuntimeHostClass();
                try
                {
                    host.EnumDomains(out enumHandle);
                    object domain = null;
                    while (true)
                    {
                        host.NextDomain(enumHandle, out domain);
                        if (domain == null) break;
                        AppDomain appDomain = (AppDomain)domain;
                        _IList.Add(appDomain);
                    }
                    return _IList;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return null;
                }
                finally
                {
                    host.CloseEnum(enumHandle);
                    Marshal.ReleaseComObject(host);
                }
            }
        }
    }
