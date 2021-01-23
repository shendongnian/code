        Dim dataTable As DataTable = New DataTable
        dataTable.Columns.Add(Me.GridColumn1.FieldName)
        dataTable.Columns.Add(Me.GridColumn2.FieldName)
        dataTable.Columns.Add(Me.GridColumn3.FieldName)
        dataTable.Columns.Add(Me.GridColumn4.FieldName)
        For Each pic In collectionToShow
            Dim row As DataRow = dataTable.NewRow()
            row(Me.GridColumn1.FieldName) = pic.Name
            row(Me.GridColumn2.FieldName) = pic.Town
            row(Me.GridColumn3.FieldName) = pic.Alias
            row(Me.GridColumn4.FieldName) = pic.Somevalue
            dataTable.Rows.Add(row)
        Next
        gcPcoSelection.DataSource = dataTable
