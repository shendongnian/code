    Public Class EntityObjectContextRepository
        Implements IRepository
        Private ReadOnly Property _context As ObjectContext
            Get
                Return UnitOfWork.Current
            End Get
        End Property
        Public Sub Add(Of T As {EntityObject, IEntity})(entity As T) Implements IRepository.Add
            _context.CreateObjectSet(Of T)().AddObject(entity)
        End Sub
        Public Sub Attach(Of T As EntityObject)(entity As T) Implements IRepository.Attach
            _context.Attach(entity)
            '_context.CreateObjectSet(Of T)().Attach(entity)
        End Sub
        Public Sub Update(Of T As {EntityObject, IEntity})(ByVal entity As T) Implements IRepository.Update
            _context.CreateObjectSet(Of T)().Attach(entity)
            _context.ObjectStateManager.ChangeObjectState(entity, EntityState.Modified)
        End Sub
        Public Function ExecuteQuery(Of T As {EntityObject, IEntity})(query As IQuery(Of T)) As IQueryResult(Of T) Implements IRepository.ExecuteQuery
            Return query.Execute(_context.CreateObjectSet(Of T))
        End Function
        Public Function ExecuteQuery(Of T As {EntityObject, IEntity}, TResult)(ByVal query As IQuery(Of T, TResult)) As IQueryResult(Of TResult) Implements IRepository.ExecuteQuery
            Return query.Execute(_context.CreateObjectSet(Of T))
        End Function
        Public Function GetAll(Of T As {EntityObject, IEntity})() As IEnumerable(Of T) Implements IRepository.GetAll
            Return _context.CreateObjectSet(Of T).ToList().Where(Function(c) c.EntityState <> EntityState.Deleted)
        End Function
        Public Function GetEntity(Of T As {EntityObject, IEntity})(id As Integer) As T Implements IRepository.GetEntity
            Dim entity = _context.CreateObjectSet(Of T)().SingleOrDefault(Function(x) x.Id = id)
            Return ReturnEntityWhenItExists(entity)
        End Function
        Public Sub Remove(Of T As EntityObject)(entity As T) Implements IRepository.Remove
            _context.DeleteObject(entity)
        End Sub
        Private Function ReturnEntityWhenItExists(Of T As {EntityObject, IEntity})(ByVal entity As T) As T
            If entity IsNot Nothing AndAlso entity.EntityState <> EntityState.Deleted Then
                Return entity
            End If
            Throw New EntityNotFoundException(Of T)()
        End Function
    End Class
