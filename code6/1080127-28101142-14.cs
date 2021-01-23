    private class Section
    {
        public string Header { get; set; }
        public List<Paragraph> Paragraphs { get; set; }
        public Section()
        {
            Paragraphs = new List<Paragraph>();
        }
    }
