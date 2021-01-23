    using (OpenFileDialog ofd = new OpenFileDialog())
    {
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            foreach (var line in File.ReadLines(ofd.FileName))
            {
                if (!line.Contains(textToFind)) { continue; }
                // do something
            }
        }
    }
