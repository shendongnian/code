     Protected Sub dgrd_WWWH_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles dgrd_WWWH.RowDataBound
    If e.Row.RowType And DataControlRowType.DataRow Then
                    Dim ColA As Label = CType(e.Row.FindControl("colA"), Label)
    Dim ColB As Label = CType(e.Row.FindControl("colB"), Label)
    If Val(ColA) > Val(ColB) then
    dgrd_WWWH.Rows(e.Row.RowIndex).Cells(2).Text = "True"
    Else
    dgrd_WWWH.Rows(e.Row.RowIndex).Cells(2).Text = "False"
    End If
    End If
    End Sub
