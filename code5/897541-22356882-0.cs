        bool processExited = true;
        private void button1_Click(object sender, EventArgs e)
        {
            if (processExited)
            {
               
                Process process = new Process();
                process.EnableRaisingEvents = true;
                process.Exited += MyProcessExited;
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.FileName = "notepad.exe";
                process.Start();
                processExited = false;
            }
            else
            {
                MessageBox.Show("Still running");
            }
        }
        void MyProcessExited(object sender, EventArgs e)
        {
            processExited = true;
        }
