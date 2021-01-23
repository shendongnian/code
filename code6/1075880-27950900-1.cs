    Private Sub YourGridView_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles YourGridView.RowDataBound
      Dim gv As GridView = sender
      If e.Row.RowType = DataControlRowType.DataRow Then
        Dim pkey As String = gv.DataKeys(e.Row.RowIndex).Values("your_report_id")
        If pkey IsNot Nothing Then
          e.Row.Attributes.Add("onclick", String.Format("ViewPopupReport('{0}');", Server.UrlEncode(pkey)))
        End If
      End If
    End Sub
