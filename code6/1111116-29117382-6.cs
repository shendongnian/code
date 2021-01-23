    private void ButtonSumbitTextboxChangesToBatch_Click(object sender, EventArgs e)
    {
        string[] lines = textBox1.Lines;
        if (lines.Length != 0)
        {
            int matchIndex = 0;
            var lineInfos = File.ReadLines(@"C:\Temp\batchTest.bat")
                .Select(l => l.Trim())
                .Select((line, index) => {
                    bool isSetLine = line.StartsWith("set ", StringComparison.InvariantCultureIgnoreCase) && line.Contains('=');
                    return new{ 
                        line, index, isSetLine,
                        setIndex = isSetLine ? matchIndex++ : -1 
                    };
                });
            string[] newLines = lineInfos
                .Select(x => !x.isSetLine || x.setIndex >= lines.Length 
                    ? x.line 
                    : string.Format("set {0}={1}",
                        x.line.Split(' ')[1].Split('=')[0].Trim(),
                        lines[x.setIndex]))
                .ToArray();
            File.WriteAllLines(@"C:\Temp\batchTest.bat", newLines);
        }
    }
