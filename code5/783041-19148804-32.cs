    Public Sub RemoveAt(ByVal index As Long)
        this.Encapsulated.Remove index
    End Sub
    Public Sub RemoveRange(ByVal Index As Long, ByVal valuesCount As Long)
        Dim i As Long
        For i = Index To Index + valuesCount - 1
            RemoveAt Index
        Next
    End Sub
    
