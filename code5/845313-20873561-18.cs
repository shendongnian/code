    Public Class Song
        Implements IMergable(Of ListViewItem)
        ...
         
        Private Sub Merge(item As ListViewItem) Implements IMergable(Of ListViewItem).Merge
            If (item Is Nothing) Then
                Throw New ArgumentNullException("item")
            End If
            Me.Title = item.SubItems(0).Text
            'Me.GetSizeInMb = Single.Parse(item.SubItems(1).Text) < -Skip, It 's a function in this example.
            Me.LastPlayed = DateTime.Parse(item.SubItems(2).Text)
            Me.Rating = Integer.Parse(item.SubItems(3).Text)
        End Sub
    End Class
