    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Configuration;
    
    namespace WinServiceProject
    {
        using System;
        using System.IO;
    
        class WinService2 : System.ServiceProcess.ServiceBase
        {
            private static string folderPath = @"c:\temp";
    
            static void Main()
            {
                System.ServiceProcess.ServiceBase[] ServicesToRun;
                ServicesToRun =
                  new System.ServiceProcess.ServiceBase[] { new WinService2() };
                System.ServiceProcess.ServiceBase.Run(ServicesToRun);
            }
    
            private void InitializeComponent()
            {
                this.ServiceName = "WinService";
            }
    
            protected override void OnStart(string[] args)
            {
                Watcher.Run();
                if (!System.IO.Directory.Exists(folderPath))
                    System.IO.Directory.CreateDirectory(folderPath);
    
                FileStream fs = new FileStream(folderPath + "\\WindowsService.txt",
                                    FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(" WindowsService: Service Started at " +
                   DateTime.Now.ToShortDateString() + " " +
                   DateTime.Now.ToShortTimeString() + "\n");
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
    
            protected override void OnStop()
            {
                FileStream fs = new FileStream(folderPath +
                  "\\WindowsService.txt",
                  FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter m_streamWriter = new StreamWriter(fs);
                m_streamWriter.BaseStream.Seek(0, SeekOrigin.End);
                m_streamWriter.WriteLine(" WindowsService: Service Stopped at " +
                  DateTime.Now.ToShortDateString() + " " +
                  DateTime.Now.ToShortTimeString() + "\n");
                m_streamWriter.Flush();
                m_streamWriter.Close();
            }
        }
    }
