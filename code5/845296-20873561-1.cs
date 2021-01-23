    Public Class MyPredefinedClass
        Public Sub New(lvi As ListViewItem)
            If (lvi Is Nothing) Then
                Throw New ArgumentNullException("lvi")
            End If
            Me.lvi = lvi
        End Sub
        Private ReadOnly lvi As ListViewItem
    End Class
