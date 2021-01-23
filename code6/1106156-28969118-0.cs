    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Reflection;
    namespace DLLTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                BackgroundWorker m_oWorker;
                m_oWorker = new BackgroundWorker();
                
                m_oWorker.DoWork += new DoWorkEventHandler(m_oWorker_DoWork);
                m_oWorker.RunWorkerAsync();
                Console.ReadLine();
            }
    
            static void m_oWorker_DoWork(object sender, DoWorkEventArgs e)
            {
                string DLLPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\TestLib.dll";
                var DLL = Assembly.LoadFile(DLLPath);
    
                foreach (Type type in DLL.GetExportedTypes())
                {
                    dynamic c = Activator.CreateInstance(type);
                    c.test();
                }
            }
       }
    }
    
