    var filePath = @"C:\Temp\temp.txt";
    var sections = new List<Section>();
    var currentSection = new Section();
    var currentParagraph = new Paragraph();
    using (TextReader reader = new StreamReader(filePath))
    {
        while (reader.Peek() >= 0)
        {
            var line = reader.ReadLine().Trim();
            // Ignore blank lines
            if (string.IsNullOrWhiteSpace(line)) continue;
            if (line.EndsWith("."))
            {
                // This line is a paragraph, so add all the sentences
                // it contains to the current paragraph
                line.Split(new[] {". "}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(l => l.Trim().TrimEnd('.'))
                    .ToList()
                    .ForEach(l => currentParagraph.Sentences.Add(l + "."));
                // Now add this paragraph to the current section
                currentSection.Paragraphs.Add(currentParagraph);
                // And set it to a new paragraph for the next loop
                currentParagraph = new Paragraph();
            }
            else if (line.Length > 0)
            {
                // This line is a header, so we're starting a new section.
                // Add the current section to our list and create a 
                // a new one, setting this line as the header.
                sections.Add(currentSection);
                currentSection = new Section {Header = line};
            }
        }
        // Finally, if the current section contains any data, add it to the list
        if (currentSection.Header.Length > 0 || currentSection.Paragraphs.Any())
        {
            sections.Add(currentSection);
        }
    }
