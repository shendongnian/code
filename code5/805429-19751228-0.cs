    private void button1_Click_1(object sender, EventArgs e)
    {
        using (w = File.AppendText(@"d:\test.txt"))
        {
            w.WriteLine("test");
        }
    }
