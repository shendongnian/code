    Sub Application_Error(ByVal sender As Object, ByVal e As EventArgs)
            Dim exception As Exception = Server.GetLastError()
            If exception Is Nothing Then
                Exit Sub
            End If
            Dim httpException As HttpException = TryCast(exception, HttpException)
            If httpException IsNot Nothing Then
                
                Dim routeData As New RouteData()
                routeData.Values.Add("controller", "Error")
                Select Case httpException.GetHttpCode()
                    Case 403, 404
                        ' page not found
                        routeData.Values.Add("action", "errorpage404")
                    Case Else
                        routeData.Values.Add("action", "errorpage40x)
                End Select
                If httpException.GetHttpCode() = 500 Then
                    'TODO
                    'Logging
                End If
    
                'routeData.Values.Add("error", exception)
                ' clear error on server
                Response.Clear()
                Server.ClearError()
                Dim errorController As IController = New ErrorController()
                errorController.Execute(New RequestContext(New HttpContextWrapper(Context), routeData))
            End If
        End Sub
