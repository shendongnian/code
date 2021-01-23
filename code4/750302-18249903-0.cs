    Public Delegate Function AllocHandlerDelegate(ByVal param1 As Integer) As Boolean
    Public Interface ILoader
        Property evAlloc As AllocHandlerDelegate
        Function Load() As Boolean
    End Interface
    Public Class MyLoader
        Implements ILoader
        Public Property evAlloc As AllocHandlerDelegate Implements ILoader.evAlloc
        Public Function Load() as Boolean Implements ILoader.Load
                If Me.evAlloc IsNot Nothing AndAlso Not evAlloc(1) Then _
                    Return False
                ' Do Stuff '
                Return True
        End Function
    End Class
