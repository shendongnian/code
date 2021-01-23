    //Open document and create DocumentBuilder
    Document doc = new Document(@"d:\\data\\Tables.docx");
    
    DocumentBuilder buildr = new DocumentBuilder(doc);
    
    //Get table from document
    Table tab = doc.FirstSection.Body.Tables[0];
    
    //We should split our table and insert breaks between parts of table.
    int count = 0;
    Table clone = (Table)tab.Clone(false);
    
    int total = tab.Rows.Count % 20;
    
    while (tab.Rows.Count  > 1)
    {
        if (tab.Rows.Count > total)
        {
            clone.AppendChild(tab.FirstRow);
        }
        else
        {
            break;
        }
        if (count == 19 )
        {
            //Insert empty paragraph after original table
            Paragraph par = new Paragraph(doc);
            tab.ParentNode.InsertBefore(par, tab);
    
            //Insert newly created table after paragraph
            par.ParentNode.InsertBefore(clone, par);
    
            //Move document builder cursor to the paragraph
            buildr.MoveTo(par);
    
            //And insert PageBreak also you can use SectionBreakNewPage
            buildr.InsertBreak(BreakType.PageBreak);
            count = 0;
            clone = (Table)tab.Clone(false);
    
        }
        else
        {
            count = count + 1;
        }
    }
    
    //Save output document
    doc.Save(@"d:\\data\\out.docx");
