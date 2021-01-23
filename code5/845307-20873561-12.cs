    Public Interface IMergable(Of T)
        Sub Merge(item As T)
    End Interface
    Public Module MyExtensions
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](Of T)(item As ListViewItem) As List(Of T)
            Dim list As New List(Of T)
            Dim obj As T = Activator.CreateInstance(Of T)()
            If (GetType(T).IsAssignableFrom(GetType(IMergable(Of ListViewItem)))) Then
                DirectCast(obj, IMergable(Of ListViewItem)).Merge(item)
                list.Add(obj)
            End If
            Return list
        End Function
        <System.Runtime.CompilerServices.Extension()> _
        Public Function [Get](Of T)(view As ListView) As List(Of T)
            Dim list As New List(Of T)
            If (GetType(T).IsAssignableFrom(GetType(IMergable(Of ListViewItem)))) Then
                Dim obj As T = Nothing
                For Each item As ListViewItem In view.Items
                    obj = Activator.CreateInstance(Of T)()
                    DirectCast(obj, IMergable(Of ListViewItem)).Merge(item)
                    list.Add(obj)
                Next
            End If
            Return list
        End Function
    End Module
