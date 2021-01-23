    Public Class UdpState
       Public e As IPEndPoint
       Public u As UdpClient
    End Class
    Public Sub UDPHelloListner()
        Dim ip As New IPEndPoint(IPAddress.Any, 15000)
        Dim udp As New UdpClient(ip)
        Dim state As New UdpState()
        state.e = ip
        state.u = udp
        udp.BeginReceive(new AsyncCallback(AddressOf Receive), state)
    End Sub
    Private Sub Receive(ByVal ar As IAsyncResult)
        Dim udp As UdpClient = CType((CType(ar.AsyncState, UdpState)).u, UdpClient)
        Dim ip As IPEndPoint = CType((CType(ar.AsyncState, UdpState)).e, IPEndPoint)
        Dim bytes As Byte() = udp.EndReceive(ar, ip)
        Dim message As String = Encoding.ASCII.GetString(bytes)
        If message = "Hello?" Then
            MessageBox.Show("I see message, Hello from {0}", ip.Address.ToString())
        End If
    End Sub
