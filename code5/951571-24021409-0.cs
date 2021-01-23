    Protected Sub GridView1_RowDataBound(ByVal sender As Object, _
          ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs)
      If e.Row.RowType.Equals(DataControlRowType.Pager) Then
      Dim pTableRow As TableRow = _
             CType(e.Row.Cells(0).Controls(0).Controls(0), TableRow)
      For Each cell As TableCell In pTableRow.Cells
        For Each control As Control In cell.Controls
          If TypeOf control Is LinkButton Then
            Dim lb As LinkButton = CType(control, LinkButton)
            lb.Attributes.Add("onclick", "ScrollToTop();")
          End If
        Next
      Next
    End If
    End Sub
