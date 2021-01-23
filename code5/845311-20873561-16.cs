    Public Module MyExtensions
        <System.Runtime.CompilerServices.Extension()> _
        Public Function ToSong(item As ListViewItem) As Song
            Dim title As String = item.SubItems(0).Text
            'Dim GetSizeInMb() As Single = Single.Parse(item.SubItems(1).Text) < -Skip, It 's a function in this example.
            Dim lastPlayed = DateTime.Parse(item.SubItems(2).Text)
            Dim rating = Integer.Parse(item.SubItems(3).Text)
            Return New Song(title, lastPlayed, rating)
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](view As ListView) As List(Of Song)
            Dim list As New List(Of Song)
            For Each item As ListViewItem In view.Items
                list.Add(item.ToSong())
            Next
            Return list
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](collection As IEnumerable(Of ListViewItem)) As List(Of Song)
            Dim list As New List(Of Song)
            For Each item As ListViewItem In collection
                list.Add(item.ToSong())
            Next
            Return list
        End Function
    End Module
