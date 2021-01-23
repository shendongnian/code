    Public Property ShowWorkText As String
        Get
            Dim navigationControl As Navigation = Me.placeHolderNav.Controls.OfType(Of Navigation)().FirstOrDefault()
            If navigationControl IsNot Nothing Then
                Return navigationControl.ShowWorkText
            End If
            Return Nothing
        End Get
        Set(value As String)
            Dim navigationControl As Navigation = Me.placeHolderNav.Controls.OfType(Of Navigation)().FirstOrDefault()
            If navigationControl IsNot Nothing Then
                navigationControl.ShowWorkText = value
            End If
        End Set
    End Property
