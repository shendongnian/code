    protected async override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        string filename = "E:\\File\\temp.txt";
        int delayTimeMilliseconds = 5000;
        // Note: File.ReadLines() defaults to UTF8.
        foreach (string line in File.ReadLines(filename))
        {
            await Task.Delay(delayTimeMilliseconds);
            richTextBox1.AppendText(line + "\n");
        }
    }
