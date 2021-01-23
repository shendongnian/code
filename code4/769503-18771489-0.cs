     Protected Sub grdServices_ItemDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.DataGridItemEventArgs)
     Dim ddlrowServices As DropDownList = e.Item.Cells(2).Controls(1)
    
                        Dim iOriginalServiceIndex As Integer = CInt(ViewState("locationOfOriginalService"))
                        ddlrowServices.SelectedIndex = iOriginalServiceIndex
    
    End Sub
