    Protected Sub GridView_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles GridView.RowDataBound
                If e.Row.RowType = DataControlRowType.Header Or e.Row.RowType = DataControlRowType.DataRow Then 
                End If
        
                If e.Row.RowType = DataControlRowType.DataRow Then
                    Dim lblColor1 As Label
        
                    lblColor1 = TryCast(e.Row.FindControl("lblColor"), Label)
        
                     lblColor1.Text = dtData.Rows(e.row.rowindex).ItemArray(0).tostring() ' 
    ' ItemArray Defined the Column Position. here give your Another Colour Column Value
                End If
          
            End Sub
