    private void MyForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Process p = Process.GetCurrentProcess();
            p.Kill();
        }
 
