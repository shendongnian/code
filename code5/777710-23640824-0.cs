    <ServiceContract()>
    Public Interface IWCFService
    
        <OperationContract()>
        Function GetData(ByVal value As Integer) As String
    
        <OperationContract()>
        Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType
    
    End Interface
    
    Public Class WCFService
        Implements IWCFService
    
        Public Shared Function CreateClient() As Object
    
        End Function
        Public Shared Sub Configure(config As ServiceConfiguration)
            'Define service endpoint
            config.AddServiceEndpoint(GetType(IWCFService), _
                                      New NetNamedPipeBinding, _
                                      New Uri("net.pipe://localhost/WCFService"))
    
            'Define service behaviors
            Dim myServiceBehaviors As New Description.ServiceDebugBehavior With {.IncludeExceptionDetailInFaults = True}
            config.Description.Behaviors.Add(myServiceBehaviors)
    
        End Sub
    
        Public Function GetData(ByVal value As Integer) As String Implements IWCFService.GetData
            Return String.Format("You entered: {0}", value)
        End Function
    
        Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IWCFService.GetDataUsingDataContract
    
        End Function
    
    End Class
