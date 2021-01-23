        Class Wrapper
            Implements IChoiceControl
            Implements IDataSourceControl
        
            Private _choiceControl As IChoiceControl
            Private _dataSource As IDataSourceControl
        
            Public Sub New(obj As Object)
                _choiceControl = CType(obj, IChoiceControl)
                _dataSource = CType(obj, IDataSourceControl)
            End Sub
        
            '' Delegate all IChoiceControl methods to _choiceControl
            '' and IDataSourceControl methods to _dataSource
        End Class
