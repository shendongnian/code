     public void SetFontType()
        {            
           this.PdfReaderContentParser = new PdfReaderContentParser(this.PdfReaderMain);
            
            //Here we see if we can read the text from the extraction. If not, we know it is a TT font.
            ITextExtractionStrategy iTextExtractionStrategy = this.PdfReaderContentParser.ProcessContent(1, new SimpleTextExtractionStrategy());
            String pdfText = iTextExtractionStrategy.GetResultantText();
            
            this.TextType = String.IsNullOrEmpty(pdfText) ? TextType.TrueTypeFont : TextType.Default;            
        }
