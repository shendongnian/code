    Public Interface IQueryResult(Of T)
        Function UniqueResult() As T
        Function List() As IEnumerable(Of T)
    End Interface
    Public Class LinqResult(Of T)
        Implements IQueryResult(Of T)
        Private ReadOnly _query As IQueryable(Of T)
        Public Sub New(query As IQueryable(Of T))
            _query = query
        End Sub
        Protected Overridable Function ExpandQuery(query As IQueryable(Of T)) As IQueryable(Of T)
            Return query
        End Function
        Public Function UniqueResult() As T Implements IQueryResult(Of T).UniqueResult
            Dim result = ExpandQuery(_query).SingleOrDefault()
            If result Is Nothing Then
                Throw New EntityNotFoundException(Of T)()
            End If
            Return result
        End Function
        Public Function List() As IEnumerable(Of T) Implements IQueryResult(Of T).List
            Return ExpandQuery(_query).ToList()
        End Function
    End Class
