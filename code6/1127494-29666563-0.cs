    Imports System.Reflection
    Public Class DynConv
    
        Public Function DynamicCast(entity As Object, [to] As Type)
            Dim openCast = Me.[GetType]().GetMethod("Cast", BindingFlags.[Static] Or BindingFlags.NonPublic)
            Dim closeCast = openCast.MakeGenericMethod([to])
            Return closeCast.Invoke(entity, New Object() {entity})
        End Function
    
    End Class
