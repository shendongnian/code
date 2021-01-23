    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.ApplicationServices;
    
    namespace Foo
    {
        static class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                var applicationBase = new ThisWindowsApplicationBase();
                applicationBase.StartupNextInstance += (sender, e) => { applicationBase.HandleCommandLine(e.CommandLine); };
                applicationBase.Run(args);
            }
        }
    
        class ThisWindowsApplicationBase : WindowsFormsApplicationBase
        {
            internal ThisWindowsApplicationBase()
                : base()
            {
                this.IsSingleInstance = true;
                this.MainForm = new Form1();
    
                this.HandleCommandLine(Environment.GetCommandLineArgs().Skip(1));
            }
    
            internal void HandleCommandLine(IEnumerable<string> commandLine)
            {
                this.MainForm.Text = "Processing: " + commandLine.FirstOrDefault();
            }
        }
    }
