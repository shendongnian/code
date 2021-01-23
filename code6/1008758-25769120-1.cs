        void Form1_Load(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                var p = Process.Start("notepad.exe");
                p.WaitForExit();
            }).ContinueWith(antecedant => { MessageBox.Show("Notepad closed"); });
        }
