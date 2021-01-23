    Public Interface IQuery(Of T As {EntityObject, IEntity})
        Function Execute(ByVal objectSet As ObjectSet(Of T)) As IQueryResult(Of T)
    End Interface
    Public Interface IQuery(Of T As {EntityObject, IEntity}, TResult)
        Function Execute(ByVal objectSet As ObjectSet(Of T)) As IQueryResult(Of TResult)
    End Interface
