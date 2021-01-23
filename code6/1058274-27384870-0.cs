    Process process;
            private void button1_Click(object sender, EventArgs e)
            {
                process = new Process();
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.FileName = "cmd";
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardInput = true;
                process.Start();
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += new DoWorkEventHandler(worker_DoWork);
                worker.RunWorkerAsync();
    
                process.StandardInput.WriteLine("cd d:/tempo" );
                process.StandardInput.WriteLine("dir");
               
               
               
            }
            void worker_DoWork(object sender, DoWorkEventArgs e)
            {
                string line;
                while (!process.StandardOutput.EndOfStream)
                {
                    line = process.StandardOutput.ReadLine();
                    if (!string.IsNullOrEmpty(line))
                    {
                        SetText(line);
                    }
                }
            }
    
            delegate void SetTextCallback(string text);
            private void SetText(string text)
            {
                if (this.textBox1.InvokeRequired)
                {
                    SetTextCallback d = new SetTextCallback(SetText);
                    this.Invoke(d, new object[] { text });
                }
                else
                {
                    this.textBox1.Text += text + Environment.NewLine;
                }
            }
            private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
            {
                process.StandardInput.WriteLine("exit");
                process.Close();
    
            }
