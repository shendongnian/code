    private static void ReplaceTags(string filename)
    {
        Regex regex = new Regex("<!(.)*?!>", RegexOptions.Compiled);
        using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(filename, true))
        {
            //grab the header parts and replace tags there
            foreach (HeaderPart headerPart in wordDocument.MainDocumentPart.HeaderParts)
            {
                ReplaceParagraphParts(headerPart.Header, regex);
            }
            //now do the document
            ReplaceParagraphParts(wordDocument.MainDocumentPart.Document, regex);
            //now replace the footer parts
            foreach (FooterPart footerPart in wordDocument.MainDocumentPart.FooterParts)
            {
                ReplaceParagraphParts(footerPart.Footer, regex);
            }
        }
    }
    private static void ReplaceParagraphParts(OpenXmlElement element, Regex regex)
    {
        foreach (var paragraph in element.Descendants<Paragraph>())
        {
            Match match = regex.Match(paragraph.InnerText);
            if (match.Success)
            {
                //create a new run and set its value to the correct text
                //this must be done before the child runs are removed otherwise
                //paragraph.InnerText will be empty
                Run newRun = new Run();
                newRun.AppendChild(new Text(paragraph.InnerText.Replace(match.Value, "some new value")));
                //remove any child runs
                paragraph.RemoveAllChildren<Run>();
                //add the newly created run
                paragraph.AppendChild(newRun);
            }
        }
    }
