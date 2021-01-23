        Public Class AuthenticationHeaderBehavior
        Implements IEndpointBehavior
    
        Private ReadOnly itsUser As String
        Private ReadOnly itsPass As String
    
        Public Sub New(ByVal user As String, ByVal pass As String)
            MyBase.New()
            itsUser = user
            itsPass = pass
        End Sub
    
        Public Sub AddBindingParameters(endpoint As ServiceEndpoint, bindingParameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
        End Sub
    
        Public Sub ApplyClientBehavior(endpoint As ServiceEndpoint, clientRuntime As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
            clientRuntime.MessageInspectors.Add(New AuthenticationHeader(itsUser, itsPass))
        End Sub
    
        Public Sub ApplyDispatchBehavior(endpoint As ServiceEndpoint, endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
        End Sub
    
        Public Sub Validate(endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
        End Sub
        End Class
