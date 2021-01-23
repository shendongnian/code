    public async Task DisplayLinesSlowly()
    {
        foreach (var line in File.ReadLines("ais.txt"))
        {
            listBox1.Items.Add(line);
            await Task.Delay(1000);
        }
    }
