    private void btnScan_Click(object sender, EventArgs e)
    {
        var code = richTextBox1.Text;
        foreach (var line in code.Split(new []{'\n','\r'}, 
            StringSplitOptions.RemoveEmptyEntries))
        {
            CheckForLoad(line);
        }
    }
    void CheckForLoad(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return;
            
        int i = line.IndexOf("#load");
        if (i < 0) return;
        int openParen = line.IndexOf("(", i + 1);
        if (openParen < 0) return;
        int closeParen = line.IndexOf(")", openParen + 1);
        if (closeParen < 0) return;
        string modules = line.Substring(openParen + 1, closeParen - openParen - 1);
        MessageBox.Show(string.Format("Loading modules: {0}", modules));
    }
