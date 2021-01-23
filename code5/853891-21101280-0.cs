    private void findToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Find f = new Find();
        f.Parent = this; // find a way to pass the Parent to your Find form.
        f.Show();
    }
    public void find(string findValue)
    {
        int idx = 0;
        if ((idx = textBox1.Text.IndexOf(findValue)) != -1)
        {
            textBox1.Select(idx, findValue.Length);
        }
    }
