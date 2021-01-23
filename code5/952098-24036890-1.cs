    private void button1_Click(object sender, EventArgs e)
    {
         var ofd = new OpenFileDialog();
         ofd.ShowDialog();
        string s = ofd.FileName;
        if (s.Length > 10)
        {
            s = s.Substring(s.Length-10, s.Length);
             textBox1.Text = "..." + s;
        }
    }
