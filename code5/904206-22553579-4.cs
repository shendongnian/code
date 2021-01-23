    Public Class UnitOfWork
        Implements IDisposable
        Private Shared _dataContext As ObjectContext
        Public Shared ReadOnly Property Current As ObjectContext
            Get
                If _dataContext Is Nothing Then
                    Throw New UnitOfWorkException(ResourceRetriever.GetResource(Of String)("ExceptionUnitOfWorkNotInitializedMessage"))
                End If
                Return _dataContext
            End Get
        End Property
        Public Sub New()
            Me.New(New REFMDataModelContainer())
        End Sub
        Public Sub New(ByVal objectContext As ObjectContext)
            If _dataContext IsNot Nothing Then
                Throw New UnitOfWorkException(ResourceRetriever.GetResource(Of String)("ExceptionUnitOfWorkAlreadyInitializedMessage"))
            End If
            _dataContext = objectContext
        End Sub
        Public Sub Complete()
            If _dataContext Is Nothing Then
                Throw New UnitOfWorkException(ResourceRetriever.GetResource(Of String)("ExceptionUnitOfWorkNotInitializedMessage"))
            End If
            _dataContext.SaveChanges()
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            If _dataContext IsNot Nothing Then
                _dataContext.Dispose()
                _dataContext = Nothing
            End If
        End Sub
    End Class
