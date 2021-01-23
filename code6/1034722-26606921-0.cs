    Public Shared ReadOnly DialogResultProperty As DependencyProperty = DependencyProperty.RegisterAttached(
        "DialogResult",
        GetType(System.Nullable(Of Boolean)),
        GetType(DialogCloser),
        New PropertyMetadata(New PropertyChangedCallback(AddressOf DialogResultChanged)))
    Private Shared Sub DialogResultChanged(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim window = TryCast(d, Window)
        If window IsNot Nothing Then
            window.DialogResult = DirectCast(e.NewValue, Nullable(Of Boolean))
        End If
    End Sub
