        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        Process p;
     /*Closing Is Timer*/
            private void Closing_Tick(object sender, EventArgs e)
        {
           
           
                p.Refresh();
                string a = p.ProcessName;              
                    SetParent(p.MainWindowHandle, panel1.Handle);
                    SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                  MoveWindow(p.MainWindowHandle, 0, 0, this.Width, this.Height, true);
                
           
        }
      void run(string add)
        {
            string addres = add;
            try
            {
                p = Process.Start(addres);
                Thread.Sleep(500); // Allow the process to open it's window
                SetParent(p.MainWindowHandle, panel1.Handle);
                SetWindowLong(p.MainWindowHandle, GWL_STYLE, WS_VISIBLE);
                MoveWindow(p.MainWindowHandle, 0, 0, this.Width, this.Height, true);
            }
            catch
            {
                Closeing.Enabled = false;
                MessageBox.Show(addres + "\n" + "Not Found", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                Environment.Exit(0);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Closeing.Enabled = true;
            run(@textBox1.Text); 
        }
