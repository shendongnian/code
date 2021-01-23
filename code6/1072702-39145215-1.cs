    Dim pdfDoc As New Document(PageSize.A4, 10.0F, 10.0F, 10.0F, 0.0F)
            Dim htmlparser As New HTMLWorker(pdfDoc)
            Using memoryStream As New MemoryStream()
                Dim writer As PdfWriter = PdfWriter.GetInstance(pdfDoc, memoryStream)
                pdfDoc.Open()
                For Each r As String In myResult
                    Dim sr As New StringReader(r)
                    htmlparser.Parse(sr)
                    pdfDoc.NewPage()
                    sr.Dispose()
                Next
                pdfDoc.Close()
                Dim bytes As Byte() = memoryStream.ToArray()
                memoryStream.Close()
                Response.Clear()
                Response.ContentType = "application/pdf"
                Response.AddHeader("Content-Disposition", "attachment;filename=Report.pdf")
                Response.Buffer = True
                Response.Cache.SetCacheability(HttpCacheability.NoCache)
                Response.BinaryWrite(bytes)
                Response.[End]()
                Response.Close()
            End Using
