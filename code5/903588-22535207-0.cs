    namespace SingleInstanceNamespace
    {
        using System;
        using System.Windows;
        using Microsoft.VisualBasic.ApplicationServices;
    
        public class SingleInstanceManager : WindowsFormsApplicationBase
        {
            public SingleInstanceManager()
            {
                this.IsSingleInstance = true;
            }
    
            protected override bool OnStartup(
                Microsoft.VisualBasic.ApplicationServices.StartupEventArgs eventArgs)
            {
                base.OnStartup(eventArgs);
                App app = new App(); //Your application instance
                app.Run();
                return false;
            }
    
            protected override void OnStartupNextInstance(
                StartupNextInstanceEventArgs eventArgs)
            {
                base.OnStartupNextInstance(eventArgs);
                string args = Environment.NewLine;
                foreach (string arg in eventArgs.CommandLine)
                    {
                    args += Environment.NewLine + arg;
                    }
                string msg = string.Format("New instance started with {0} args.{1}",
                eventArgs.CommandLine.Count,
                args);
                MessageBox.Show(msg);
            }
        }
    }
