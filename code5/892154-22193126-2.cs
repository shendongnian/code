    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        Task.Factory.StartNew(loadTextLineByLine);
    }
    private void loadTextLineByLine()
    {
        string filename = "E:\\File\\temp.txt";
        int delayTimeMilliseconds = 5000;
        foreach (string line in File.ReadLines(filename))
        {
            Thread.Sleep(delayTimeMilliseconds);
            string text = line; // Prevent modified closure.
            this.BeginInvoke(new Action(() => richTextBox1.AppendText(text + "\n")));
        }
    }
