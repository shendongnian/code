    private void button1_Click(object sender, EventArgs e)
    {
        System.Diagnostics.Process.Start("osk.exe");
        //SetFocus to your TextBox here
        textBox1.Focus();
    }
    
    private void textbox1_LostFocus(object sender, EventArgs e)
    {
        var procs = Process.GetProcessesByName("osk");
        if (procs.Length != 0)
            procs[0].Kill();
    }
