    Dim table As DataTable = (
        From row As DataRow
        In ds.Tables("Client")
        Let clientId As Int32 = row.Field(Of Int32)("ClientID")
        Where clientId > 30
        Order By clientId Ascending
        Select row
    ).Take(10).CopyToDataTable()
