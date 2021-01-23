    // Instantiate an accessible ServiceHost-type variable. Notice, the GetType() call
    // Each subsequent call sets the service up for SOAP and REST (WebHTTPBinding), and
    // adds various behaviors to the service, including metadata behavior:
    Private Sub ConfigureServiceHost(ByVal aHostName As String, ByVal aPort As Integer)
        Dim URL As String = String.Format("http://{0}:{1}/Service/", aHostName, aPort)
        _ServiceHost = New ServiceHost(GetType(DualService), New Uri(URL))
        AddWebHTTPBinding()
        AddSOAPBinding()
        AddServiceBehavior()
    End Sub
    // Here, again, notice the call to GetType() - another reason for separating our interfaces
    Private Sub AddWebHTTPBinding()
        Dim _WebHTTPBinding As New WebHttpBinding
        Dim EndPoint As ServiceEndpoint
        Dim _WebHTTPBehavior As New WebHttpBehavior
        _WebHTTPBinding.MaxReceivedMessageSize = Int32.MaxValue
        _WebHTTPBinding.SendTimeout = New System.TimeSpan(0, 5, 0)
        _WebHTTPBinding.ReceiveTimeout = New System.TimeSpan(0, 5, 0)
        // If these calls are foreign, look them up in MSDN. Here, you are adding an EndPoint
        // to _ServiceHost of type IREST, with the specified behavior, at location "/WebService"
        EndPoint = _ServiceHost.AddServiceEndpoint(GetType(IREST), _WebHTTPBinding, "WebService")
        EndPoint.Behaviors.Add(_WebHTTPBehavior)
    End Sub
    // Let's set up SOAP:
    Private Sub AddSOAPBinding()
        Dim _BasicHTTPBinding As New BasicHttpBinding
        Dim EndPoint As ServiceEndpoint
        // See the comment for the similar call in the AddWebHttpBinding call:
        EndPoint = _ServiceHost.AddServiceEndpoint(GetType(ISOAP), _BasicHTTPBinding, "SOAP")
    End Sub
    // Let's get our metadata on, y'all!:
    Private Sub AddServiceBehavior()
        Dim _ServiceMetadataBehavior As ServiceMetadataBehavior = New ServiceMetadataBehavior
        _ServiceMetadataBehavior.HttpGetEnabled = True
        _ServiceHost.Description.Behaviors.Add(_ServiceMetadataBehavior)
    End Sub
