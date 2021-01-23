    PdfPage page = document.AddPage();
            if (image.Height > 1000)
            {
                page.Size = PageSize.A1;
            }
            else
            {
                page.Size = PageSize.A2;
            }
