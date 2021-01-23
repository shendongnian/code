    private void checkexe_CheckedChanged(object sender, EventArgs e)
    {
        string line;
        System.IO.StreamReader file = new System.IO.StreamReader("patcher.conf");
        while ((line = file.ReadLine()) != null)
        {
            var lines = File.ReadAllLines("patcher.conf");
            lines[1] = checkexe.Checked.ToString();
            File.WriteAllLines("patcher.conf", lines);
        }
        file.Close();
    }
