    Friend Class ReadResources
    
        ' Get our assembly.
        Private Shared executingAssembly As System.Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
    
        ' Get our namespace.
        Private Shared myNamespace As String = executingAssembly.GetName().Name.ToString()
    
        ''' <summary>
        ''' Generate resource link
        ''' </summary>
        Friend Shared Function GetResourceLink(ByVal ref As String,
                                               ByVal obj As Object,
                                               ByVal page As Web.UI.Page) As String
            Dim out As String = Nothing
            out = Page.ClientScript.GetWebResourceUrl(obj.GetType, myNamespace & "." & ref)
    
            If out Is Nothing OrElse out.Length <= 0 Then
                out = FindResource(ref, obj)
            End If
    
            Return out
        End Function
    
        Friend Shared Function FindResource(ByVal reference As String,
                                            ByVal obj As Object) As String
            Dim out As String = ""
            For Each embedded In obj.GetType().Assembly.GetManifestResourceNames()
                If embedded.Contains(reference) Then
                    out = embedded
                    Exit For
                End If
            Next
            Return out
        End Function
    
    
    End Class
