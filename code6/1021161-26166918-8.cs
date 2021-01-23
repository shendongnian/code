    Imports Shell32
    Private exList As New List(Of String) '
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
      
        Dim exShell As New Shell
        
        exList.Clear()
        For Each win As ShellBrowserWindow In DirectCast(exShell.Windows, IShellWindows)
            thisPath = ""
            If TryCast(win.Document, IShellFolderViewDual) IsNot Nothing Then
                thisPath = DirectCast(win.Document, IShellFolderViewDual).FocusedItem.Path
            ElseIf TryCast(win.Document, ShellFolderView) IsNot Nothing Then
                thisPath = DirectCast(win.Document, ShellFolderView).FocusedItem.Path
            End If
            If String.IsNullOrEmpty(thisPath) = False Then
                ExplorerFiles.Add(thisPath)
            End If
        Next
    End Sub
