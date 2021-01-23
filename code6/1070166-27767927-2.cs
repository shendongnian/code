    using System;
    using System.Threading;
    using System.Windows.Forms;
    using MouseKeyboardActivityMonitor.WinApi;
    namespace Demo
    {
        internal class KeyboardHook : IDisposable
        {
            private readonly KeyboardHookListener _hook = new KeyboardHookListener(new     GlobalHooker());
            public KeyboardHook()
            {
                _hook.KeyDown += hook_KeyDown;
                _hook.Enabled = true;
            }
            private void hook_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.Alt && e.KeyCode == Keys.F12)
                    MessageBox.Show(@"Alt+Ctrl+F12 Pressed.");
            }
            public void Dispose()
            {
                _hook.Enabled = false;
                _hook.Dispose();
            }
        }
        internal static class Program
        {
            private static void Main()
            {
                var t = new Thread(() =>
                {
                    using (new KeyboardHook())
                        Application.Run();
                });
                t.Start();
                Console.WriteLine(@"press 'C' key to exit application...");
                while (Console.ReadKey().Key != ConsoleKey.C){}
                Application.Exit();
            }
        }
    }
