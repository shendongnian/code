    Protected Sub grdFinYear_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles grdFinYear.RowDataBound
    If e.Row.RowType = DataControlRowType.DataRow Then
        If grdFinYear.DataKeys(e.Row.RowIndex).Values("FIN_ID") = FIN_ID Then
            Dim activeButton As Button = e.Row.FindControl("btnSelect")
            activeButton.CssClass = "ActionButtonsActiveYear"
            activeButton.CommandName = "ActiveButton"
            activeButton.CommandArgument = **Bind to Year for this row**
            e.Row.BackColor = Color.FromArgb(0, 121, 139, 169)
        Else
            Dim makeActiveButton As Button = e.Row.FindControl("btnSelect")
            makeActiveButton.CssClass = "ActionButtonsMakeThisYearActive"
            makeActiveButton.CommandName = "MakeActiveButton"
            makeActiveButton.CommandArgument = **Bind to Year for this row**
        End If
    End If
    End Sub
