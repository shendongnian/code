                Chunk chunk = new Chunk("Underlined TExt", FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12.0f, iTextSharp.text.Font.BOLD | iTextSharp.text.Font.UNDERLINE));
                Paragraph reportHeadline = new Paragraph(chunk);
                reportHeadline.SpacingBefore = 12.0f;
                pdfDoc.Add(reportHeadline);
               
