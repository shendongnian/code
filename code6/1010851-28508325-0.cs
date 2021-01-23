    Private Sub TreeViewItem_MouseMove(sender As Object, e As MouseEventArgs)
            _dragObject = sender.DataContext
            If _dragObject IsNot Nothing AndAlso e.LeftButton = MouseButtonState.Pressed AndAlso MovedMinimumDistance(e) Then
                DragDrop.DoDragDrop(tb, _dragObject, DragDropEffects.Move)
            End If
    End Sub
    Private Function MovedMinimumDistance(e As MouseEventArgs) As Boolean
            Return Math.Abs(e.GetPosition(Nothing).X - _downPoint.X) >= SystemParameters.MinimumHorizontalDragDistance AndAlso
            Math.Abs(e.GetPosition(Nothing).Y - _downPoint.Y) >= SystemParameters.MinimumVerticalDragDistance
    End Function
