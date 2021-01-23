    Private Sub RadDropDownList1_SelectedIndexChanged(sender As Object, e As Data.PositionChangedEventArgs) _
    Handles RadDropDownList1.SelectedIndexChanged
    
        sender.DropDownListElement.
               EditableElement.
               TextAlignment = ContentAlignment.MiddleCenter
    
    End Sub
