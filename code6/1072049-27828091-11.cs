        bool Stop = false;
        Thread thread;
        private void StartButton_Click(object sender, EventArgs e)
        {
            string FileName = @"...\a.bin";
            thread = new Thread(new ThreadStart(() => DoLongProcess(FileName)));
            thread.IsBackground = true;
            thread.Start();
        }
        private void StopButton_Click(object sender, EventArgs e)
        {
            Stop = true;
        }
        private void DoLongProcess(string file)
        {
            using (BinaryReader reader = new BinaryReader(File.Open(file, FileMode.Open)))
            {
                int pos = 0;
                int length = (int)reader.BaseStream.Length;
                while (pos < length)
                {
                    if (Stop)
                        thread.Abort();
                    // using Invoke if you want cross UI objects
                    this.Invoke((MethodInvoker)delegate
                    {
                        label1.Text = pos.ToString();
                    });
                    pos += sizeof(int);
                }
            }
        }
