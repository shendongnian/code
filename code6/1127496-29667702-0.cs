     Public Function DynamicCast(ByVal entity As Object, ByVal [to] As Type) As Dynamic.ExpandoObject
        Dim c = New Test()
        Dim openCast = Me.GetType().GetMethod("Cast",BindingFlags.Static Or BindingFlags.NonPublic)
        Dim closeCast = openCast.MakeGenericMethod([to])
        Return closeCast.Invoke(entity, New Object() {New Object() {entity}})
    End Function
