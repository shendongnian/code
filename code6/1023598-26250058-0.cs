    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        Try
              
                Dim myControl1 As Control =directcast(Page.FindControl("pnlfindid"),Control)
                If (Not myControl1 Is Nothing) Then
                    myControl1.Visible = False
    
                End If
    
    
            Catch ex As Exception
    
            End Try
        End Sub
