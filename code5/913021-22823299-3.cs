    private void checkexe_CheckedChanged(object sender, EventArgs e)
    {
        var lines = File.ReadAllLines("patcher.conf");
        for(var i = 0; i < lines.Length; i++)
        {
            if (i == 1)
                lines[i] = checkexe.Checked.ToString();
        }
        File.WriteAllLines("patcher.conf", lines);
    }
