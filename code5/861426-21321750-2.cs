    class Copy
    {
        public event EventHandler ProcessExited;
        private bool IsCopyComplete;
        ....
        public void GetNewCopy()
        {
            Process proc = new Process();
            IsCopyComplete = false;
            proc.EnableRaisingEvents = true;
            proc.Exited += ProcessExited;
            proc.Exited += new EventHandler(myProcess_Exited);
            proc.StartInfo = new ProcessStartInfo("cmd.exe"); // specify your process - replace cmd.exe with whatever's appropriate
            proc.Start();
        }
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            IsCopyComplete = true;
        }
    }
