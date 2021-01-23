        private async void button1_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            await Task.Run(() =>
            {
                var myProc = Process.Start("calc");
                myProc.WaitForExit();
            });            
            this.Enabled = true;
        }
