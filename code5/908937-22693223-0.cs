    Private Sub ShowNewPage()
        Dispatcher.Invoke(Sub() ShowNewPageCallback())
    End Sub
    Private Sub ShowNewPageCallback()
        If contentPresenter.Content IsNot Nothing Then
            Dim oldPage As UserControl = TryCast(contentPresenter.Content, UserControl)
            If oldPage IsNot Nothing Then
                RemoveHandler oldPage.Loaded, AddressOf newPage_Loaded
                UnloadPage(oldPage)
            End If
        Else
            ShowNextPage()
        End If
    End Sub
