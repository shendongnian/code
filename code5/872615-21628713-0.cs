    foreach (Word.Section section in document.Sections)
    {
        foreach (Word.HeaderFooter wordFooter in section.Headers)
        {
            foreach (Word.Paragraph para in wordFooter.Range.Paragraphs) // see the change of wordFooter in this line
            {
                para.Range.Delete();
            }
        }
    }
