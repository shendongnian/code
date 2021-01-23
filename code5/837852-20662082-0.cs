    private async Task WriteText(string text)
    {
        foreach (char c in text)
        {
            TxtDisplayAppendText(c.ToString());
            await Task.Delay(rnd.Next(20, 100));
        }
    }
