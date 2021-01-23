    // Open a stream for the source file
    using (var sourceFile = File.OpenText(fileName))
    {
        // Create a temporary file path where we can write modify lines
        string tempFile = Path.Combine(Path.GetDirectoryName(fileName), "story-temp.txt");
        // Open a stream for the temporary file
        using (var tempFileStream = new StreamWriter(tempFile)) 
        {
            string line;
            // read lines while the file has them
            while ((line = sourceFile.ReadLine()) != null) 
            {
                // Do the word replacement
                line = line.Replace("tea", "cabbage");
                // Write the modified line to the new file
                tempFileStream.WriteLine(line);
            }
        }
    }
    // Replace the original file with the temporary one
    File.Replace("story-temp.txt", "story.txt", null);
