    Module DynConv
    
        Public Function DynamicCast(entity As Object, [to] As Type)
            Dim openCast = GetType(DynConv).GetMethod("Cast", BindingFlags.[Static] Or BindingFlags.NonPublic)
            Dim closeCast = openCast.MakeGenericMethod([to])
            Return closeCast.Invoke(entity, New Object() {entity})
        End Function
    
        Private Function Cast(Of t)(input As Object)
            ' ...?
            ' return something
        End Function
    
    End Module
