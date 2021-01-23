    Protected Sub SqlDataSource1_Selected(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.SqlDataSourceStatusEvent Args) Handles
    SqlDataSource1.Selected
    
      Dim cnt As Integer = e.AffectedRows
    
    End Sub
