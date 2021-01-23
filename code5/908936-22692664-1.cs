    Private Sub ShowNewPage()
        Dispatcher.Invoke(DirectCast(
                              Sub()
                                  If contentPresenter.Content IsNot Nothing Then
                                      Dim oldPage As UserControl = TryCast(contentPresenter.Content, UserControl)
    
                                      If oldPage IsNot Nothing Then
                                          oldPage.Loaded -= newPage_Loaded
                                          UnloadPage(oldPage)
                                      End If
                                  Else
                                      ShowNextPage()
                                  End If
                              End Sub, 
                              Action))
    End Sub
