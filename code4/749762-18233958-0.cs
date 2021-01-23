    using (var reader = File.OpenText("file.txt"))
    {
        for (int i = 0; i < 25; i++)
        {
            HandleLines(reader);
        }
    }
    ...
    private void HandleLines(TextReader reader)
    {
        for (int i = 0; i < 20; i++)
        {
            string line = reader.ReadLine();
            if (line != null) // Handle the file ending early
            {
                // Process the line
            }
        }
    }
