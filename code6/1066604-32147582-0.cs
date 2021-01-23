    // Create a document.
    using (DocX document = DocX.Create(@"Test.docx"))
    {
        Table t;
        using (DocX document2 = DocX.Load(@"Test2.docx"))
        {
            t = document2.Tables[0];
        }        
        // Specify some properties for this Table.
        t.Alignment = Alignment.center;
        t.Design = TableDesign.MediumGrid1Accent2;
        // Add content to this Table.
        t.Rows[0].Cells[0].Paragraphs.First().Append("A");
        t.Rows[0].Cells[1].Paragraphs.First().Append("B");
        t.Rows[0].Cells[2].Paragraphs.First().Append("C");
        t.Rows[1].Cells[0].Paragraphs.First().Append("D");
        t.Rows[1].Cells[1].Paragraphs.First().Append("E");
        t.Rows[1].Cells[2].Paragraphs.First().Append("F");
        // Insert the Table into the document.
        document.InsertTable(t);
        document.Save();
    }// Release this document from memory.
