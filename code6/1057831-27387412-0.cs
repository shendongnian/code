     // Read paragraph upto and including first ":"
            string text =  (paragraph.Inlines.FirstInline as Run).Text;
            int r = text.IndexOf(":")+1;
            string Title = text.Substring(0,r).Trim();
            // Remove Title from text;
            string newtext = text.Substring(r).Trim();
            // Insert new inline and remove the old inline.
            Inline z = paragraph.Inlines.FirstInline;
            Run runx = new Run(newtext);
            paragraph.Inlines.InsertBefore(z, runx);
            paragraph.Inlines.Remove(z);
            this.Note = paragraph;
