    public void Log(string logText)
    {
        while (logQueue.Count > logMax - 1)
            logQueue.Dequeue();
        logQueue.Enqueue(logText);
        textBox.Text = string.Join(Environment.NewLine, logQueue.ToArray());
    }
