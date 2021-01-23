     Private Sub lpTable_DataBound(sender As Object, e As EventArgs) Handles lpTable.DataBound
         Panel1.Visible = (lpTable.Rows.Count > 0)
     End Sub
    
     Private Sub wsTable_DataBound(sender As Object, e As EventArgs) Handles wsTable.DataBound
         Panel2.Visible = (wsTable.Rows.Count > 0)
     End Sub
