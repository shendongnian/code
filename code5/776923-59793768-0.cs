Private Sub RemoveHyperlinksFromPdf(ByRef fileloc As String)
        Dim pdfReader As New PdfReader(fileloc)
        For i = 1 To pdfReader.NumberOfPages
            Dim pageDict As PdfDictionary = pdfReader.GetPageN(i)
            Dim annots As PdfArray = pageDict.GetAsArray(PdfName.ANNOTS)
            Dim newAnnots As PdfArray = New PdfArray()
            If annots IsNot Nothing Then
                For j As Integer = 0 To annots.Size() - 1
                    Dim annotDict As PdfDictionary = annots.GetAsDict(i)
                    If Not PdfName.LINK.Equals(annotDict.GetAsName(PdfName.SUBTYPE)) Then
                        newAnnots.Add(annots.GetAsDict(j))
                    End If
                Next
                pageDict.Put(PdfName.ANNOTS, newAnnots)
            End If
        Next
        Dim pdfStamper As PdfStamper = Nothing
        Dim extension = Path.GetExtension(fileloc)
        Dim filename As String = Path.GetFileNameWithoutExtension(fileloc)
        Dim filePath As String = Path.GetDirectoryName(fileloc)
        fileloc = filePath + "\" + filename + "new" + extension
        pdfStamper = New PdfStamper(pdfReader, New FileStream(fileloc, FileMode.Create))
        pdfStamper.FormFlattening = False
        pdfStamper.Close()
        pdfReader.Close()
    End Sub```
