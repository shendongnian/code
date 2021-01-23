    Private ReadOnly udp As New UdpClient(15000)
    Public Sub UDPHelloListner()
        udp.BeginReceive(new AsyncCallback(AddressOf Receive), New Object())
    End Sub
    Private Sub Receive(ByVal ar As IAsyncResult)
        Dim ip As New IPEndPoint(IPAddress.Any, 15000)
        Dim bytes As Byte() = udp.EndReceive(ar, ip)
        Dim message As String = Encoding.ASCII.GetString(bytes)
        If message = "Hello?" Then
            Dim sender As New IPEndPoint(IPAddress.Any, 15000)
            Dim senderRemote As EndPoint = CType(sender, EndPoint)
            MessageBox.Show("I see message, Hello")
        End If
        UDPHelloListner()
    End Sub
