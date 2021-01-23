            Process[] ps;
            DateTime timeout = DateTime.Now.AddSeconds(30);
            do
            {
                System.Threading.Thread.Sleep(100);
                ps = Process.GetProcessesByName("notepad"); // <--- no path, AND no extension (just the EXE name)
            } while (ps.Length == 0 && timeout > DateTime.Now);
            if (ps.Length > 0)
            {
                ShowWindow(ps[0].MainWindowHandle, 0);
            }
            else
            {
                MessageBox.Show("Process Not Found within Timeout Period", "Process Failed to Spawn");
            }
