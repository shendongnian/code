    Private Sub cboProducts_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboProducts.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim pdt, pdtid As String
            Dim i As Integer
            pdt = cboProducts.Columns(0).Text
            pdtid = cboProducts.Columns(1).Text.ToString
            grdSale.SetDataBinding()
            If grdSale.Rows.Count = 0 Then
                i = 0
            Else
                i = i + grdSale.Rows.Count
            End If
            grdSale.AddRows(1)
            grdSale(i, 0) = pdt
            grdSale(i, 1) = pdtid
        End If
    End Sub
