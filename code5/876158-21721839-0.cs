    private void ProcessLines(List<string> lines)
    {
        // lines holds the previously read lines from the textfile
        foreach (string line in lines)
        {
            string[] parts = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parts[2] == "A")
            {
                // code to process a line of code in Group A, etc.
            }
        }
    }
