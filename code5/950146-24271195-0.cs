      var doc = new Document();
            var pdf = "D:/Temp/pdfs/" + DateTime.Now.ToString("yyyymmdd") + ".pdf"; // mm ??
            PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(pdf, FileMode.Create));
            doc.Open();
            PdfContentByte canvas = writer.DirectContent;
            ColumnText ct = new ColumnText(canvas);
            int side_of_the_page = 0;
            ct.SetSimpleColumn(COLUMNS[side_of_the_page]);
            int paragraphs = 0;
            while (paragraphs < 30)
            {
                ct.AddElement(new iTextSharp.text.Paragraph(String.Format("Paragraph %s: %s", ++paragraphs, "SOME STUFF")));
                while (ColumnText.HasMoreText(ct.Go()))
                {
                    if (side_of_the_page == 0)
                    {
                        side_of_the_page = 1;
                        canvas.MoveTo(297.5f, 36);
                        canvas.LineTo(297.5f, 806);
                        canvas.Stroke();
                    }
                    else
                    {
                        side_of_the_page = 0;
                        doc.NewPage();
                    }
                    ct.SetSimpleColumn(COLUMNS[side_of_the_page]);
                }
            }
            doc.Close();
