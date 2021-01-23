            TextBlock Item = new TextBlock();
            Code = Code.Replace("\t", new String(' ', Editor.Options.IndentationSize));
            
            TextDocument Document = new TextDocument(Code);
            IHighlightingDefinition HighlightDefinition = Editor.SyntaxHighlighting;
            IHighlighter Highlighter = new DocumentHighlighter(Document, HighlightDefinition.MainRuleSet);
            int LineCount = Document.LineCount;
            for (int LineNumber = 1; LineNumber <= Document.LineCount; LineNumber++)
            {
                HighlightedLine Line = Highlighter.HighlightLine(LineNumber);
                string LineText = Document.GetText(Line.DocumentLine);
                int Offset = Line.DocumentLine.Offset;
                int SectionCount = Line.Sections.Count;
                for (int SectionNumber = 0; SectionNumber < SectionCount; SectionNumber++)
                {
                    HighlightedSection Section = Line.Sections[SectionNumber];
                    //Deal with previous text
                    if (Section.Offset > Offset)
                    {
                        Item.Inlines.Add(
                            new Run(Document.GetText(Offset, Section.Offset - Offset))
                        );
                    }
                    Run RunItem = new Run(Document.GetText(Section));
                    if (RunItem.Foreground != null)
                    {
                        RunItem.Foreground = Section.Color.Foreground.GetBrush(null);
                    }
                    if (Section.Color.FontWeight != null)
                    {
                        RunItem.FontWeight = Section.Color.FontWeight.Value;
                    }
                    Item.Inlines.Add(RunItem);
                    Offset = Section.Offset + Section.Length;
                }
                //Deal with stuff at end of line
                int LineEnd = Line.DocumentLine.Offset + LineText.Length;
                if (LineEnd > Offset)
                {
                    Item.Inlines.Add(
                        new Run(Document.GetText(Offset, LineEnd-Offset))
                    );
                }
                //If not last line add a new line
                if (LineNumber < LineCount)
                {
                    Item.Inlines.Add(new Run("\n"));
                }
            }
