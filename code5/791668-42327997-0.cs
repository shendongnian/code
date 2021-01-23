    Private allowdrag As Boolean
    Private Sub lv_PreviewMouseLeftButtonDown(sender As Object, e As MouseButtonEventArgs) Handles lvAttributesDefault.PreviewMouseLeftButtonDown
        Dim listView As ListView = TryCast(sender, ListView)
        allowdrag = e.GetPosition(sender).X < listView.ActualWidth - SystemParameters.VerticalScrollBarWidth And e.GetPosition(sender).Y < listView.ActualHeight - SystemParameters.HorizontalScrollBarHeight
    End Sub
    Private Sub lv_MouseMove(sender As Object, e As MouseEventArgs) Handles lvAttributesDefault.MouseMove
        Dim listView As ListView = TryCast(sender, ListView)
        If e.LeftButton = MouseButtonState.Pressed And listView.SelectedItem IsNot Nothing And allowdrag Then
            Dim obj As clsAttribute = CType(listView.SelectedItem, clsAttribute)
            Dim dragData As New DataObject("clsAttribute", obj)
            DragDrop.DoDragDrop(listView, dragData, DragDropEffects.Copy)
        End If
    End Sub
