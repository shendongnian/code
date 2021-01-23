        Partial Class ExampleDomainContext
        
          Private Sub OnCreated()
            Dim channelFactoryProperty As PropertyInfo = Me.DomainClient.GetType().GetProperty("ChannelFactory")
            If (channelFactoryProperty IsNot Nothing) Then
                Dim factory = TryCast(channelFactoryProperty.GetValue(Me.DomainClient, Nothing), channelFactory)
                If factory IsNot Nothing Then
                    If Not factory.Endpoint.Behaviors.Contains(GetType(Infrastructure.WebServices.AttachRequestInformationEndpointBehavior)) Then
                        factory.Endpoint.Behaviors.Add(New Wintouch.Infrastructure.WebServices.AttachRequestInformationEndpointBehavior())
                    End If
                End If
            End If
          End Sub
        End Class
