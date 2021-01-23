    using System;
    using System.Windows;
    using System.Diagnostics;
    using System.IO;
    namespace WpfApplication1
    {
        internal class MainWindow : Window
        {
            public MainWindow()
            { }
            [STAThread()]
            static void Main(string[] args)
            {
                if (args.Length == 0)
                {
                    // [ show error or print usage ]
                    return;
                }
                if (!File.Exists(args[0]))
                {
                    // [ show error or print usage ]
                    return;
                }
                // Perform the copy
                FileInfo target = new FileInfo(args[0]);
                string destinationFilename = string.Format("X:\\ExistingFolder\\{0}", target.Name);
                File.Copy(target.FullName, destinationFilename);
                // You may need to place the filename in quotes if it contains spaces
                string targetPath = string.Format("\"{0}\"", target.FullName); 
                string powerpointPath = "[FullPathToPowerpointExecutable]";
                Process powerpointInstance = Process.Start(powerpointPath, targetPath);
                // This solution is using a wpf windows app to avoid 
                // the flash of the console window.  However if you did
                // wish to display an accumulated list then you may choose
                // to uncomment the following block to display your UI.
                /*
                Application app = new Application();
                app.MainWindow = new MainWindow();
                app.MainWindow.ShowDialog();
                app.Shutdown(0);
                */
                Environment.Exit(0);
            }
        }
    }
