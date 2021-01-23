    Imports System.ServiceModel.Channels
    Imports System.ServiceModel.Description
    Imports System.ServiceModel.Dispatcher
    
    Public Class MaxFaultSizeBehavior
        Implements IEndpointBehavior
    
        Private ReadOnly _size As Integer
    
        Public Sub New(ByVal size As Integer)
            _size = size
        End Sub
    
        Public Sub Validate(ByVal endpoint As ServiceEndpoint) Implements IEndpointBehavior.Validate
        End Sub
    
        Public Sub AddBindingParameters(ByVal endpoint As ServiceEndpoint, ByVal bindingParameters As BindingParameterCollection) Implements IEndpointBehavior.AddBindingParameters
        End Sub
    
        Public Sub ApplyDispatchBehavior(ByVal endpoint As ServiceEndpoint, ByVal endpointDispatcher As EndpointDispatcher) Implements IEndpointBehavior.ApplyDispatchBehavior
        End Sub
    
        Public Sub ApplyClientBehavior(ByVal endpoint As ServiceEndpoint, ByVal clientRuntime As ClientRuntime) Implements IEndpointBehavior.ApplyClientBehavior
            clientRuntime.MaxFaultSize = _size
        End Sub
    End Class
