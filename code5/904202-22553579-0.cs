    Public Interface IRepository
        Function GetEntity(Of T As {EntityObject, IEntity})(id As Integer) As T
        Function GetAll(Of T As {EntityObject, IEntity})() As IEnumerable(Of T)
        Sub Add(Of T As {EntityObject, IEntity})(entity As T)
        Sub Remove(Of T As EntityObject)(entity As T)
        Sub Attach(Of T As EntityObject)(entity As T)
        Sub Update(Of T As {EntityObject, IEntity})(entity As T)
        Function ExecuteQuery(Of T As {EntityObject, IEntity})(query As IQuery(Of T)) As IQueryResult(Of T)
        Function ExecuteQuery(Of T As {EntityObject, IEntity}, TResult)(query As IQuery(Of T, TResult)) As IQueryResult(Of TResult)
    End Interface
