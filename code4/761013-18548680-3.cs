    using System;
    using System.Diagnostics;
    using System.Windows;
    namespace So18547663WpfScreenSaverPreview
    {
        public partial class MainWindow
        {
            private Process saver;
            public MainWindow ()
            {
                InitializeComponent();
            }
            private void MainWindow_OnLoaded (object sender, RoutedEventArgs e)
            {
                saver = Process.Start(new ProcessStartInfo {
                    FileName = "Bubbles.scr",
                    Arguments = "/p " + host.Child.Handle,
                    UseShellExecute = false,
                });
            }
            private void MainWindow_OnClosed (object sender, EventArgs e)
            {
                // Optional. Screen savers should close themselves
                // when the parent window is destroyed.
                saver.Kill();
            }
        }
    }
