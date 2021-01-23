    Public Class Song
        Public Sub New()
            Me.New(String.Empty, DateTime.Now, 0)
        End Sub
        Public Sub New(title As String, lastPlayed As DateTime, rating As Integer)
            Me.Title = title
            Me.LastPlayed = lastPlayed
            Me.Rating = rating
        End Sub
        Public Property Title() As String
        Public Property LastPlayed() As DateTime
        Public Property Rating() As Integer
        Public Function GetSizeInMb() As Single
            Return 1.2
        End Function
    End Class
