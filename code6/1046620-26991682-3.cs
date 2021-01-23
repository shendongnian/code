    #define __USE_AS_CONSOLE___
    
    using MyService.Service;
    using System;
    using System.Collections.Generic;
    using System.Configuration.Install;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Diagnostics;
    
    namespace MyService
    {
        public class Program
        {
            #region Private Member
            private static ASServiceBase myServiceBase;
            private static string serviceName;
            #endregion
    
            #region Console
            const bool ShowConsole = true;
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool AllocConsole();
    
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool FreeConsole();
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool SetDllDirectory(string lpPathName);
    
            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            static extern bool AddDllDirectory(string lpPathName);
            #endregion
    
            static void Main(string[] args)
            {
                AppDomain.CurrentDomain.AssemblyResolve += ResolveError;
                
                string installCommand = "";
                serviceName = GetServiceName();
    
                foreach(string arg in args)
                {
                    if (arg.ToLower().StartsWith("/install"))
                    {
                        installCommand = "/install";
                    }
                    else if (arg.ToLower().StartsWith("/uninstall"))
                    {
                        installCommand = "/uninstall";
                    }
                }
    
                if (System.Environment.UserInteractive)
                {
                    string parameter = "";
    
                    foreach (string arg in args)
                    {
                        parameter += arg;
    
                        if (!arg.EndsWith(" "))
                        {
                            parameter += "";
                        }
                    }
    
                    switch (installCommand)
                    {
                        case "/install":
                            if (!IsAdministrator())
                            {
                                System.Console.WriteLine("Die Anwendung muss als Administrator installiert werden.");
                                System.Console.ReadLine();
                                return;
                            }
    
                            ManagedInstallerClass.InstallHelper(new string[] { Assembly.GetExecutingAssembly().Location });
                            return;
                            break;
                        case "/uninstall":
                            if (!IsAdministrator())
                            {
                                System.Console.WriteLine("Die Anwendung muss als Administrator installiert werden.");
                                System.Console.ReadLine();
                                return;
                            }
    
                            ManagedInstallerClass.InstallHelper(new string[] { "/u", Assembly.GetExecutingAssembly().Location });
                            return;
                            break;
                    }
    
                    AllocConsole();
                    myServiceBase = new ASServiceBase();
                    myServiceBase.Start();
                    System.Console.ReadLine();
                }
                else
                {
                    // ===============================================
                    // Start Console
                    AllocConsole();
                    System.Console.WriteLine("Version 1.0");
    
                    myServiceBase = new ASServiceBase();
    
                    //Start service
                    System.ServiceProcess.ServiceBase.Run(myServiceBase);
    
                }
            }
    
            public static bool IsAdministrator()
            {
                var identity = WindowsIdentity.GetCurrent();
                var principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
    
            #region [Resolve Error]
            /// <summary>
            /// Resolve Error
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private static Assembly ResolveError(object sender, ResolveEventArgs args)
            {
                try
                {
                    Assembly cMyAssembly = null;
                    string strTempAssmbPath = string.Empty;
    
                    Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
                    AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();
    
                    AssemblyName myAssemblyName = Array.Find<AssemblyName>(arrReferencedAssmbNames, a => a.Name == args.Name);
    
                    if (myAssemblyName != null)
                    {
                        cMyAssembly = Assembly.LoadFrom(myAssemblyName.CodeBase);
                    }
                    else
                    {
                        string rootFolder = GetAssemblyPath(args, "");
                        if (!string.IsNullOrEmpty(rootFolder))
                        {
                            if (File.Exists(rootFolder))
                            {
                                // Loads the assembly from the specified path.                  
                                cMyAssembly = Assembly.LoadFrom(rootFolder);
                            }
                        }
    
                        string assemblyFolder = GetAssemblyPath(args, "Assemblies\\");
                        if (!string.IsNullOrEmpty(assemblyFolder))
                        {
                            if (File.Exists(assemblyFolder))
                            {
                                // Loads the assembly from the specified path.                  
                                cMyAssembly = Assembly.LoadFrom(assemblyFolder);
                            }
                        }
                    }
    
                    // Returns the loaded assembly.
                    return cMyAssembly;
                }
                catch (Exception exc)
                {
                    FileLog.WriteLog("Fehler in Init.ResolveError:\r\n" + exc.ToString());
                    return null;
                }
            }
    
            private static string GetAssemblyPath(ResolveEventArgs args, string AdditionalDirectory)
            {
                string returnValue = null;
    
                string cRMSAssemblyFolder = GlobalSettings.StudioPath + "\\" + AdditionalDirectory;
    
                Assembly cMyAssembly = null;
                string strTempAssmbPath = string.Empty;
    
                Assembly objExecutingAssemblies = Assembly.GetExecutingAssembly();
                AssemblyName[] arrReferencedAssmbNames = objExecutingAssemblies.GetReferencedAssemblies();
    
                AssemblyName myAssemblyName = Array.Find<AssemblyName>(arrReferencedAssmbNames, a => a.Name == args.Name);
    
                if (myAssemblyName == null)
                {
                    if (args.Name.Contains(","))
                    {
                        strTempAssmbPath = Path.Combine(cRMSAssemblyFolder, args.Name.Substring(0, args.Name.IndexOf(",")) + ".dll");
                    }
                    else
                    {
                        strTempAssmbPath = Path.Combine(cRMSAssemblyFolder, args.Name + ".dll");
                    }
    
                    returnValue = strTempAssmbPath;
                }
    
                return returnValue;
            }
            #endregion
        }
    }
