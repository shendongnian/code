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
            float page1Height, page1Width, page2Height, page2Width;
            page1Height = reader.GetPageSizeWithRotation(i - 1).Height;
            page1Width = reader.GetPageSizeWithRotation(i - 1).Width;
            page2Height = reader.GetPageSizeWithRotation(i).Height;
            page2Width = reader.GetPageSizeWithRotation(i).Width;
            cb.AddTemplate(page, (page1Width - page2Width) / 2, (page1Height - page2Height) / 2);
        }
    }
