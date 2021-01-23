    Dim invoices As New List(Of InvoiceDto)()
    Dim serializer As New XmlSerializer(GetType(InvoiceDto))
    For Each i As XmlNode In doc.SelectNodes("/invoiceListResponse/invoiceList/invoiceListItem")
        Using reader As New StringReader("<invoice>" & i.InnerXml & "</invoice>")
            invoices.Add(DirectCast(serializer.Deserialize(reader), InvoiceDto))
        End Using
    Next
