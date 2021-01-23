    dim host As New ServiceHost(GetType(ExampleService))
         Dim bindingElements As ICollection(Of BindingElement) = New List(Of BindingElement)()
            Dim MessageEncodingElement As New MessageEncodingBindingElement()
            ServerMessageEncodingElement.ContentEncryption = ContentEncryptionType.All
            ServerMessageEncodingElement.ContentCompression = ContentCompressionType.None
            Dim httpBindingElement As New HttpTransportBindingElement()
            bindingElements.Add(MessageEncodingElement)
            bindingElements.Add(httpBindingElement)
            Dim binding As New CustomBinding(bindingElements)
            Dim endpoint As ServiceEndpoint = host.AddServiceEndpoint(GetType(IExampleService), binding, "http://" & My.Computer.Name & "/Example")
            Dim col = New ReadOnlyCollection(Of IAuthorizationPolicy)(New IAuthorizationPolicy() {New AuthorizationPolicy()})
            Dim sa As ServiceAuthorizationBehavior = host.Description.Behaviors.Find(Of ServiceAuthorizationBehavior)()
            sa.ExternalAuthorizationPolicies = col
            sa.PrincipalPermissionMode = PrincipalPermissionMode.Custom
            Dim sm As ServiceAuthenticationBehavior = host.Description.Behaviors.Find(Of ServiceAuthenticationBehavior)()
            sm.ServiceAuthenticationManager = New AuthenticationManager
            host.Open()
