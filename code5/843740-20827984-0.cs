    using (StreamReader reader = File.OpenText("some file name"))
    {
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            if (line.StartsWith(textBoxInput.Text, StringComparison.OrdinalIgnoreCase))
            {
                // At this point we've already read the keyword and it matches our input
                StringBuilder description = new StringBuilder(512);
                string descLine;
                // Here we start reading description lines after the keyword.
                // Because every keyword with description is separated by blank line
                // we continue reading the file until, the last read line is empty 
                // (separator between keywords) or its null (eof)
                while ((descLine = reader.ReadLine()) != string.Empty && descLine != null)
                {
                    description.AppendLine(descLine);
                }
                textBoxDescription.Text = description.ToString();
                break;
            }
        }
    }
