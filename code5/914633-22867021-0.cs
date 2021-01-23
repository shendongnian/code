    Imports Microsoft.VisualBasic
    Public Class MsgBox
    Public Shared Sub Show(ByRef page As Page, ByVal strMsg As String)
        Try
            Dim lbl As New Label
            lbl.Text = "<script language='javascript'>" & Environment.NewLine _
                        & "window.alert(" & "'" & strMsg & "'" & ")</script>"
            page.Controls.Add(lbl)
        Catch ex As Exception
        End Try
    End Sub 
    End Class
