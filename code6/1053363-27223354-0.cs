        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcessesByName("calc"))
            {
                p.EnableRaisingEvents = true;
                p.Exited += p_Exited;
            }
        }
        void p_Exited(object sender, EventArgs e)
        {
            foreach (Process p in Process.GetProcessesByName("notepad"))
            {
                p.CloseMainWindow();
            }
        }
