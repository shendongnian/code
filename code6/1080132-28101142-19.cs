    private void Form1_Load(object sender, EventArgs e)
    {
        var filePath = @"C:\Temp\temp.txt";
        
        var sentences = File.ReadAllLines(filePath)
            // Only select lines that end in a period
            .Where(l => l.Trim().EndsWith("."))
            // Split each line into sentences (one line may have many sentences)
            .SelectMany(s => s.Split(new[] {'.'}, StringSplitOptions.RemoveEmptyEntries))
            // Trim any whitespace off the ends of the sentence and add a period to the end
            .Select(s => s.Trim() + ".")
            // And finally cast it to a List (or you could do 'ToArray()')
            .ToList();
        // To show each sentence in the list on it's own line in the rtb:
        richTextBox1.Text = string.Join("\n", sentences);
        // Or to show them all, one after another:
        richTextBox1.Text = string.Join(" ", sentences);
    }
