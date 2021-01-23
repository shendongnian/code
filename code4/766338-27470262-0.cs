        Dim stamper As iTextSharp.text.pdf.PdfStamper = Nothing
        Dim cb As iTextSharp.text.pdf.PdfContentByte = Nothing
        Dim rect As iTextSharp.text.Rectangle = Nothing
        Dim pageCount As Integer = 0
        Try
            reader = New iTextSharp.text.pdf.PdfReader(oldFile)
            rect = reader.GetPageSizeWithRotation(1)
            stamper = New iTextSharp.text.pdf.PdfStamper(reader, New System.IO.FileStream(newFile, IO.FileMode.Create))
 
            cb = stamper.GetOverContent(1)
            Dim ct = New ColumnText(cb)
            ct.Alignment = Element.ALIGN_LEFT
            ct.SetSimpleColumn(70, 36, PageSize.A4.Width - 36, PageSize.A4.Height - 300)
            Dim nTbl As PdfPTable = New PdfPTable(2)
            'create column sizes 
            Dim rows As Single() = {135.0F, 145.0F}
            'set row width 
            nTbl.SetTotalWidth(rows)
            nTbl.AddCell(New Paragraph("Application Ref No:", FontFactory.GetFont("Arial", 15)))
            nTbl.AddCell(New Paragraph("HPOBM00017", FontFactory.GetFont("Arial", 15)))
            'coords x=300,y=300
            '  nTbl.WriteSelectedRows(0, 50, 40, 835, stamper.GetOverContent(1))
            nTbl.WriteSelectedRows(0, 20, 300, 835, stamper.GetOverContent(1))
            stamper.Close()
            reader.Close()
            ct.Go()
      
        Catch ex As Exception
            Throw ex
        End Try
