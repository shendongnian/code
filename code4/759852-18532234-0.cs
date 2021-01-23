    Module SqlParameterExtensions
      <Extension()>
      Public Sub MyAddWithValue(coll As SqlParameterCollection, paramName As String, paramValue As Object)
        If (TypeOf paramValue Is DocumentNumber) Then
            coll.AddWithValue(paramName, paramValue.ToString())
        Else
            coll.AddWithValue(paramName, paramValue)
        End If
      End Sub
    End Module
