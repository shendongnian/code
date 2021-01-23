    Private Sub ScrollViewer_OnScrollChanged(ByVal sender As Object, ByVal e As ScrollChangedEventArgs)
    
        For Each item As MapInfo In LbFancy.Items
            If (item.Expanded) Then
    
                Dim positionTransform = item.TransformToAncestor(LbFancy)
                Dim itemPosition = positionTransform.Transform(New Point(0, 0))
    
                If ((itemPosition.Y > 0) And (itemPosition.Y < e.ViewportHeight)) Then
                    ' The top of the item is visible
                ElseIf ((itemPosition.Y < 0) And (itemPosition.Y + item.ActualHeight - button.Height > 0)) Then
                    ' the top of the item is not visible but a part of the item is
                    Dim button = CType(item.FindName("ButtonExpander"), Button)
                    Canvas.SetTop(button, 0 - itemPosition.Y)
                End If
            End If
        Next
    
    End Sub
