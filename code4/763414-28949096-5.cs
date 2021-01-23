     Private Sub MenuItem_Click(sender As Object, e As RoutedEventArgs)
            Dim row As DataGridRow = DirectCast(DirectCast(DirectCast(sender, MenuItem).GetParentObject, ContextMenu).PlacementTarget, DataGridRow)
            'replace with what ever item you want
            Dim srvr As Server = DirectCast(row.Item, Server)
        End Sub
