    Public Shared Function GetPath() As String
        Dim page = TryCast(HttpContext.Current.Handler, Page)
        If page IsNot Nothing Then
            Return page.AppRelativeVirtualPath
        Else
            Return Nothing
        End If
    End Function
 
