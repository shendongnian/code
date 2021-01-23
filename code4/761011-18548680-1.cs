    using System;
    using System.Diagnostics;
    using System.Windows;
    using System.Windows.Forms;
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
                Control preview = new Control("preview") {
                    Width = (int)host.Width,
                    Height = (int)host.Height
                };
                host.Child = preview;
                saver = Process.Start(new ProcessStartInfo(
                    "Bubbles.scr", "/p " + preview.Handle) {
                        UseShellExecute = false,
                    });
            }
            private void MainWindow_OnClosed (object sender, EventArgs e)
            {
                saver.Kill();
            }
        }
    }
