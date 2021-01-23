    Imports Microsoft.AspNet.SignalR.Client
    Imports Microsoft.AspNet.SignalR.Client.Hubs
    Imports Microsoft.AspNet.SignalR.Client.Transports
    Imports System.Threading.Tasks
    ''' <summary>
    ''' Methods and properties that relate to the Communication Hub.
    ''' Use to push data from the Server to the Client via SignalR.
    ''' </summary>
    ''' <remarks>
    ''' We are using shared variables, we can help prevent race conditions by initiating this class by calling the StartUp method from the application_start event
    ''' </remarks>
    Public Class CommHub
        Private Shared Property Connection As HubConnection
        Private Shared Property Proxy As IHubProxy
        Private Shared ReadOnly _connectionLock As Object = New Object
        Private Sub New()
        End Sub
        ''' <summary>
        ''' Start up the connection to the realtime communication servers.
        ''' Call on application_start event.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub Startup()
            Task.Run(Async Function()
                         'async must be run on a new thread:
                         Dim commHub As New CommHub
                         Await commHub.ConnectAsync()
                     End Function)
        End Sub
        ''' <summary>
        ''' Establishes an authenticated connection to the SignalR server.
        ''' </summary>
        ''' <remarks></remarks>
        Private Async Function ConnectAsync() As Tasks.Task
            'set connection to server:
            If IsNothing(Connection) Then
                SyncLock _connectionLock
                    If IsNothing(Connection) Then
                        Dim realtimeUrl As String = "http://myserver/signalr"
                        Connection = New HubConnection(realtimeUrl)
                        'OPTIONAL:
                        'add custom headers:
                        'Connection.Headers.Add("headername", "headervalue")
                        'OPTIONAL:
                        'get realtime authentication cookie with permission to communicate with the realtime servers:
                        'Dim authCookie As Net.Cookie = Code_to_get_your_auth_cookie
                        'Connection.CookieContainer = New Net.CookieContainer
                        'Connection.CookieContainer.Add(authCookie)
                        'define hub proxy to connect to:
                        Proxy = Connection.CreateHubProxy("commHub")
                    End If
                End SyncLock
            End If
            If Not IsNothing(Connection) Then
                Dim myConnection As HubConnection = Connection ' get pointer reference to shared object
                If myConnection.State = ConnectionState.Disconnected Then
                    Try
                        'Two way communication is not required as we are only pushing data to the signalR server.
                        'Therefore we should use ServerSentEventsTransport as it is more efficient than websockets.
                        'Explicitly setting the transport type speeds up connection - otherwise connection transport is auto detected:
                        Await myConnection.Start(New ServerSentEventsTransport())
                    Catch ex As Exception
                        'catch multiple connection attempts
                        'do nothing
                    End Try
                End If
            End If
        End Function
        Public Enum CounterTypes As Integer
            Messages
            Requests
            Notifications
        End Enum
        ''' <summary>
        ''' Updates the counter on the specified client in realtime.
        ''' </summary>
        ''' <param name="mbrID">The unique id of the client.</param>
        ''' <param name="counterType">The type of counter.</param>
        ''' <param name="value">The value of the counter.</param>
        ''' <remarks></remarks>
        Friend Shared Async Sub UpdateCounterAsync(mbrID As Integer, counterType As CounterTypes, value As Integer)
            're-establish connection if it has been dropped 
            'otherwise reuses the existing connection 
            Dim commHub As New CommHub
            Await commHub.ConnectAsync()
            'call server side method:
            If Not IsNothing(Connection) Then
                Dim myConnection As HubConnection = Connection 'get pointer reference to shared object
                If myConnection.State = ConnectionState.Connected Then
                    Dim myProxy As IHubProxy = Proxy 'get pointer reference to shared object
                    If Not IsNothing(myProxy) Then
                        'invoke method on signalR server:
                        Await myProxy.Invoke("UpdateCounter", mbrID, counterType.ToString, value)
                    End If
                End If
            End If
        End Sub
    End Class
