    // loop over document pages
    for (int i = 1; i <= pages; i++)
    {
        doc.NewPage();
        page = writer.GetImportedPage(reader, i);
        if (i == 1)
        {
           cb.AddTemplate(page, 0, 0);
        }
        else
        {
           cb.AddTemplate(page, -35, -40);
        }
    }
