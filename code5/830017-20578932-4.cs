    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.ServiceProcess;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace DeveloperWorkbench.UI
    {
        public partial class Form2 : Form
        {
            public Form2()
            {
                InitializeComponent();
    
                this.ProgressChanged += Service_ProgressChanged;
                this.MaxProgressChanged += Service_MaxProgressChanged;
            }
    
            private delegate void IntDelegate(int value);
    
            private event IntDelegate ProgressChanged;
            private event IntDelegate MaxProgressChanged;
    
            private void Service_ProgressChanged(int value)
            {
                if (InvokeRequired)
                    this.Invoke(new IntDelegate(Service_ProgressChanged), value);
                else
                {
                    lblProgress.Text = value.ToString();
                    progressBar1.Value = value;
                }
            }
    
            private void Service_MaxProgressChanged(int value)
            {
                if (InvokeRequired)
                    this.Invoke(new IntDelegate(Service_MaxProgressChanged), value);
                else
                {
                    progressBar1.Maximum = value;
                }            
            }
    
            private void UpdateServiceProgress(ServiceController serviceController)
            {
                int progress = 0;
                var maxProgressList = new List<int>(){119,120,744,745, 746};
                int maxProgressIndex = 0;
                int maxProgress = 747;
                bool tripped =  false;
                
                MaxProgressChanged(maxProgress);
                try
                {
                    IntPtr smHandle = NativeMethods.OpenSCManager(null, null, NativeMethods.ServiceAccess.ENUMERATE_SERVICE);
                    if (smHandle != IntPtr.Zero)
                    {
                        IntPtr svHandle = NativeMethods.OpenService(smHandle, serviceController.ServiceName, NativeMethods.ServiceAccess.ENUMERATE_SERVICE);
                        if (svHandle != IntPtr.Zero)
                        {
                            var servStat = new NativeMethods.SERVICE_STATUS();
                            while (servStat.dwCurrentState != NativeMethods.ServiceState.Running)
                            {
                                if (NativeMethods.QueryServiceStatus(svHandle, servStat))
                                {
                                    progress += servStat.dwCheckPoint;
                                    if (progress > maxProgress)
                                    {
                                        maxProgressIndex++;
                                        if (maxProgressIndex < maxProgressList.Count)
                                        {
                                            maxProgress = maxProgressList[maxProgressIndex];
                                            MaxProgressChanged(maxProgress);
                                        }
                                        else
                                            tripped = true;
                                    }
    
                                    ProgressChanged(progress);
                                }
    
                            }
                            
                            NativeMethods.CloseServiceHandle(svHandle);
                        }
                        NativeMethods.CloseServiceHandle(smHandle);
                    }
                }
                catch (System.Exception)
                {
    
                }
                if (tripped)
                {
                    maxProgressList.Add(progress);
                    Console.WriteLine("max progress {0}", progress);
                }
                    
            }
    
            public static class NativeMethods
            {
                [DllImport("AdvApi32")]
                public static extern IntPtr OpenSCManager(string machineName, string databaseName, ServiceAccess access);
                [DllImport("AdvApi32")]
                public static extern IntPtr OpenService(IntPtr serviceManagerHandle, string serviceName, ServiceAccess access);
                [DllImport("AdvApi32")]
                public static extern bool CloseServiceHandle(IntPtr serviceHandle);
                [DllImport("AdvApi32")]
                public static extern bool QueryServiceStatus(IntPtr serviceHandle, [Out] SERVICE_STATUS status);
    
                [Flags]
                public enum ServiceAccess : uint
                {
                    ALL_ACCESS = 0xF003F,
                    CREATE_SERVICE = 0x2,
                    CONNECT = 0x1,
                    ENUMERATE_SERVICE = 0x4,
                    LOCK = 0x8,
                    MODIFY_BOOT_CONFIG = 0x20,
                    QUERY_LOCK_STATUS = 0x10,
                    GENERIC_READ = 0x80000000,
                    GENERIC_WRITE = 0x40000000,
                    GENERIC_EXECUTE = 0x20000000,
                    GENERIC_ALL = 0x10000000
                }
    
                public enum ServiceState
                {
                    Stopped = 1,
                    StopPending = 3,
                    StartPending = 2,
                    Running = 4,
                    Paused = 7,
                    PausePending = 6,
                    ContinuePending = 5
                }
    
                [StructLayout(LayoutKind.Sequential, Pack = 1)]
                public class SERVICE_STATUS
                {
                    public int dwServiceType;
                    public ServiceState dwCurrentState;
                    public int dwControlsAccepted;
                    public int dwWin32ExitCode;
                    public int dwServiceSpecificExitCode;
                    public int dwCheckPoint;
                    public int dwWaitHint;
                };
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                progressBar1.Value = 0;
                progressBar1.Maximum = 0;
    
                var service = new ServiceController("MSSQLSERVER");
                if (service.Status == ServiceControllerStatus.Running)
                {
                    service.Stop(); 
                    service.WaitForStatus(ServiceControllerStatus.Stopped);
                }
                service.Start();
                var task = new Task(() => UpdateServiceProgress(service));
                task.Start();
            }
    
        }
    }
