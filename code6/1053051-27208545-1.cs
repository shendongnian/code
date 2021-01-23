    Private Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim parentPage As IPageGuidHost
        parentPage = TryCast(Me.Page, IPageGuidHost)
        If parentPage IsNot Nothing Then
            labelTotal.Text = parentPage.PageNameGuid
        Else
            lableTotal.Text = String.Empty
        End If
    End Sub
