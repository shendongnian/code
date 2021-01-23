    Public Class AttachRequestInformationEndpointBehavior
        Implements IEndpointBehavior, IClientMessageInspector
        Public Sub AddBindingParameters(endpoint As ServiceEndpoint, bindingParameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
        End Sub
        Public Sub ApplyClientBehavior(endpoint As ServiceEndpoint, clientRuntime As System.ServiceModel.Dispatcher.ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
            clientRuntime.MessageInspectors.Add(Me)
        End Sub
        Public Sub ApplyDispatchBehavior(endpoint As ServiceEndpoint, endpointDispatcher As System.ServiceModel.Dispatcher.EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
        End Sub
        Public Sub Validate(endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
        End Sub
        Public Sub AfterReceiveReply(ByRef reply As Message, correlationState As Object) Implements IClientMessageInspector.AfterReceiveReply
        End Sub
        Public Function BeforeSendRequest(ByRef request As Message, channel As IClientChannel) As Object Implements IClientMessageInspector.BeforeSendRequest
            Dim header As HttpRequestMessageProperty
            If request.Properties.ContainsKey(HttpRequestMessageProperty.Name) Then
                header = CType(request.Properties(HttpRequestMessageProperty.Name), HttpRequestMessageProperty)
            Else
                header = New HttpRequestMessageProperty()
                request.Properties.Add(HttpRequestMessageProperty.Name, header)
            End If
            header.Headers("Authorization") = "Bearer " + "the user token here..."
            
            Return Nothing
        End Function
