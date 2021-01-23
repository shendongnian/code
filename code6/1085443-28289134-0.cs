    Friend Class DominoCollection
        Private mcol As Dictionary(Of Integer, Domino)
    
        Public Sub New()
            mcol = New Dictionary(Of Integer, Domino)
        End Sub
    
        Public Sub Add(dom As Domino)
            If mcol.ContainsKey(dom.key) = False Then
                mcol.Add(dom.key, dom)
            End If
        End Sub
    
        Public Function Contains(dom As Domino) As Boolean
            Return mcol.ContainsKey(dom.key)
        End Function
    
    End Class
