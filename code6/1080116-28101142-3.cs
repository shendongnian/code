    private void Form1_Load(object sender, EventArgs e)
    {
        var filePath = @"C:\Temp\temp.txt";
        
        var sentences = File.ReadAllLines(filePath)
            .Where(l => l.Trim().EndsWith("."))
            .SelectMany(s => s.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries))
            .Select(s => s.Trim() + ".")
            .ToList();
        // To show each sentence in the list on it's own line in the rtb:
        richTextBox1.Text = string.Join("\n", sentences);
        // Or to show them all, one after another:
        richTextBox1.Text = string.Join(" ", sentences);
    }
