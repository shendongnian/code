    Private Sub GridView1_RowCellClick(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs) Handles GridView1.RowCellClick
        Dim myColumn As String = e.Column.FieldName ' for the datasource column name
               Dim myValue = GridView1.GetFocusedDataRow(myColumn)
        'For a standard one column
        myValue = view.GetFocusedDataRow("ColumnX")
    End Sub
