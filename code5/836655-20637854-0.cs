    private void Form1_Click(object sender, EventArgs e)
    {
        Stopwatch sw = new Stopwatch();
        sw.Reset();
        textBox1.Text = "";
        sw.Start();
        for (int i = 0; i < 10000; i++)
        {
            textBox1.Text += s;
        }
        sw.Stop();
        var e1 = sw.Elapsed;
        sw.Reset();
        textBox1.Text = "";
        sw.Start();
        for (int i = 0; i < 10000; i++)
        {
            textBox1.AppendText(s);
        }
        sw.Stop();
        var e2 = sw.Elapsed;
    }
