    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Security.Principal;
    
    
    namespace SingleRun
    {
        class Program
        {
            static void Main(string[] args)
            {
                string path = "";
                var prog = "";
                if (args.Length == 0) {
                    MessageBox.Show("Please include a program to start.\n\nExample: \nSingleRun.exe \"C:\\Program Files\\Windows NT\\Accessories\\wordpad.exe\"", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    System.Environment.Exit(1);
                }else{
                    path = args[0];
                    if (!File.Exists(path)) {
                        MessageBox.Show("\"" + path + "\" does not exist.\nPlease check the location.\nAnything with spaces in it needs to be inside double-quotes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        System.Environment.Exit(1);
                    }else{
                        var splits = path.Split('\\');
                        prog = splits[splits.Length - 1];
                        foreach (var p in Process.GetProcessesByName(prog.Replace(".exe",""))) {
                            string processOwner;
                            try {
                                processOwner = p.WindowsIdentity().Name;
                            }
                            catch (Exception ex) {
                                processOwner = ex.Message; // Probably "Access is denied"
                            }
                            if (processOwner.Contains(Environment.UserName)) {
                                MessageBox.Show("Program already running with PID " + p.Id, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                System.Environment.Exit(1);
                            }
                        }
                        Process newProcess = Process.Start(path);
                        Console.WriteLine("Launching " + prog + " with PID: " + newProcess.Id);
                    }
                }
            }
        }
    
        /// <summary>
        /// Extension Methods for the System.Diagnostics.Process Class.
        /// </summary>
        public static class ProcessExtensions {
            /// <summary>
            /// Required to query an access token.
            /// </summary>
            private static uint TOKEN_QUERY = 0x0008;
    
            /// <summary>
            /// Returns the WindowsIdentity associated to a Process
            /// </summary>
            /// <param name="process">The Windows Process.</param>
            /// <returns>The WindowsIdentity of the Process.</returns>
            /// <remarks>Be prepared for 'Access Denied' Exceptions</remarks>
            public static WindowsIdentity WindowsIdentity(this Process process) {
                IntPtr ph = IntPtr.Zero;
                WindowsIdentity wi = null;
                try {
                    OpenProcessToken(process.Handle, TOKEN_QUERY, out ph);
                    wi = new WindowsIdentity(ph);
                }
                catch (Exception) {
                    throw;
                }
                finally {
                    if (ph != IntPtr.Zero) {
                        CloseHandle(ph);
                    }
                }
    
                return wi;
            }
    
            [DllImport("advapi32.dll", SetLastError = true)]
            private static extern bool OpenProcessToken(IntPtr processHandle, uint desiredAccess, out IntPtr tokenHandle);
    
            [DllImport("kernel32.dll", SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool CloseHandle(IntPtr hObject);
        }
    }
