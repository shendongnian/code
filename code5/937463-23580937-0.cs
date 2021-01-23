    private void MethodOne()
    {
        progressBar1.Value = 0;
        String[] a = textBox7.Text.Split('#');
        progressBar1.Maximum = a.Length;
        for (var i = 0; i <= a.GetUpperBound(0); i++)
        {
            ansh.Close();
            progressBar1.Value++;
        }
    }
    private void MethodTwo()
    {
        foreach (string item in listBox2.Items)
            textBox7.Text += item.Contains("@") ? string.Format("{0}#", item.Split('@')[0]) : string.Empty;
    }
    private void button1_Click(object sender, EventArgs e)
    {
        MethodTwo();
        MethodOne();
    }
    private void button2_Click(object sender, EventArgs e)
    {
        MethodTwo();
    }
