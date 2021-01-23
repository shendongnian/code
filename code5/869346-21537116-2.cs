    private void button2_Click(object sender, EventArgs e)
    {
        var procs = Process.GetProcessesByName("osk");
        if (procs.Length != 0)
            procs[0].Kill();
          
    }
