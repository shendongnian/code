    private void button2_Click(object sender, EventArgs e)
    {
        string destination = textBox1.Text;
        string srcdir = mapping["111"];
        foreach(var f in Directory.GetFiles(srcdir))
        {
             string srcpath = Path.Combine(srcdir, f)
             File.Copy(srcpath, destination);
        }
    }
